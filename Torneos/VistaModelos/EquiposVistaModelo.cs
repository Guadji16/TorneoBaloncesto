using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Torneos.Modelos;
using Torneos.Servicios;
using Torneos.VistaModelos;
using Xamarin.Forms;

namespace Torneos.VistaModelos
{
    public class EquiposVistaModelo : BaseVistaModelo
    {
        
        #region Constructor
        public EquiposVistaModelo()
        {
            servicios = new FirebaseDB();
            equipoColeccion.Clear();
            equipoColeccion = servicios.obtenerEquipos();
        }
        #endregion

        #region Atributos
        private FirebaseDB servicios;
        private EquipoModelo equipoSeleccionado;
        private string categoriaSeleccionada;
        private string tipoSeleccionado;
        private string txtNombre;
        private string txtNJugadores;
        private string txtLocalidad;
        private ObservableCollection<EquipoModelo> equipoColeccion = new ObservableCollection<EquipoModelo>();
        #endregion

        #region Propiedades
        public ObservableCollection<EquipoModelo> EquipoColeccion
        {
            get { return this.equipoColeccion; }
            set { SetValue(ref this.equipoColeccion, value); }
        }
        public EquipoModelo EquipoSeleccionado
        {
            get { return this.equipoSeleccionado; }
            set { SetValue(ref this.equipoSeleccionado, value); }
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
        public string TxtNJugadores
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
        public ICommand EquipoSeleccionadoComando
        {
            get
            {
                return new RelayCommand(EquipoSeleccionadoMetodo);
            }
        }
        public ICommand GuardarComando
        {
            get
            {
                return new RelayCommand(GuardarMetodo);
            }
        }
        public ICommand CancelarComando
        {
            get
            {
                return new RelayCommand(CancelarMetodo);
            }
        }
        #endregion

        #region Metodos
        private async void EquipoSeleccionadoMetodo()
        {
            
        }
        private async void GuardarMetodo()
        {
            await Application.Current.MainPage.DisplayAlert("Sistema", "Modelo guardado correctamente   ", "OK");
            EquipoModelo nuevoEquipo = new EquipoModelo()
            {
                id = Guid.NewGuid(),
                nombre = TxtNombre,
                nJugadores = Int32.Parse(TxtNJugadores),
                tipo = TipoSeleccionado,
                categoria = CategoriaSeleccionada,
                localidad = TxtLocalidad
            };
            await servicios.agregarEquipo(nuevoEquipo);
            
        }
        private async void CancelarMetodo()
        {
            TxtNombre = "";
            TxtNJugadores = "";
            CategoriaSeleccionada = "";
            TipoSeleccionado = "";
            TxtLocalidad = "";
        }
        #endregion
    }
}
