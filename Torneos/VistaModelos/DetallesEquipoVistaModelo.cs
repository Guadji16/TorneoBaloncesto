
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Torneos.Modelos;
using Torneos.Servicios;
using Xamarin.Forms;

namespace Torneos.VistaModelos
{
    public class DetallesEquipoVistaModelo : BaseVistaModelo
    {
        #region Constructor
        public DetallesEquipoVistaModelo()
        {

        }

        public DetallesEquipoVistaModelo(EquipoModelo _equipo)
        {
            servicios = new FirebaseDB();
            IDEquipo = _equipo.id;
            CategoriaSeleccionada = _equipo.categoria;
            TipoSeleccionado = _equipo.tipo;
            TxtNombre = _equipo.nombre;
            TxtNJugadores = _equipo.nJugadores;
            TxtLocalidad = _equipo.localidad;
        }
        #endregion

        #region Atributos
        private FirebaseDB servicios;
        private Guid idEquipo;
        private string categoriaSeleccionada;
        private string tipoSeleccionado;
        private string txtNombre;
        private int txtNJugadores;
        private string txtLocalidad;
        #endregion

        #region Propiedades
        public Guid IDEquipo
        {
            get { return this.idEquipo; }
            set { SetValue(ref this.idEquipo, value); }
        }
        public string CategoriaSeleccionada
        {
            get { return this.categoriaSeleccionada; }
            set { SetValue(ref this.categoriaSeleccionada, value); }
        }
        public string TipoSeleccionado
        {
            get { return this.tipoSeleccionado; }
            set { SetValue(ref this.tipoSeleccionado, value); }
        }
        public string TxtNombre
        {
            get { return this.txtNombre; }
            set { SetValue(ref this.txtNombre, value); }
        }
        public int TxtNJugadores
        {
            get { return this.txtNJugadores; }
            set { SetValue(ref this.txtNJugadores, value); }
        }
        public string TxtLocalidad
        {
            get { return this.txtLocalidad; }
            set { SetValue(ref this.txtLocalidad, value); }
        }
        #endregion

        #region Comandos
        public ICommand ActualizarComando
        {
            get
            {
                return new RelayCommand(ActualizarMetodo);
            }
        }

        public ICommand EliminarComando
        {
            get
            {
                return new RelayCommand(EliminarMetodo);
            }
        }
        #endregion

        #region Metodos
        private async void ActualizarMetodo()
        {
            await Application.Current.MainPage.DisplayAlert("Sistema", "Equipo actualizado correctamente   ", "OK");
            EquipoModelo nuevoEquipo = new EquipoModelo()
            {
                id = IDEquipo,
                nombre = TxtNombre,
                nJugadores = TxtNJugadores,
                tipo = TipoSeleccionado,
                categoria = CategoriaSeleccionada,
                localidad = TxtLocalidad
            };
            await servicios.actualizarEquipo(nuevoEquipo);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void EliminarMetodo()
        {
            await Application.Current.MainPage.DisplayAlert("Sistema", "Equipo eliminado correctamente   ", "OK");
            await servicios.eliminarEquipo(IDEquipo);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}
