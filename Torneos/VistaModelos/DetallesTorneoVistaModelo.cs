using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Torneos.Modelos;
using Torneos.Servicios;
using Xamarin.Forms;

namespace Torneos.VistaModelos
{
    class DetallesTorneoVistaModelo : BaseVistaModelo
    {
        #region Constructor
        public DetallesTorneoVistaModelo()
        {
            cargarDatos();
          
        }

        public DetallesTorneoVistaModelo(TorneoModelo _torneo)
        {
            servicios = new FirebaseDB();
            IDTorneo = _torneo.id;
            TxtNombre = _torneo.nombre;
            TxtLocalidad = _torneo.lugar;
            TxtFecha = _torneo.fecha;
            


        }
        #endregion

        #region Atributos
        private FirebaseDB servicios;
        private Guid idEquipo;
        private string nombreTorneo;
        private string localidad;
        private string fecha;
        private string equipo;
        public object listaDatos;
        public bool isRefreshing = false;



        #endregion

        #region Propiedades
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public Guid IDTorneo
        {
            get { return this.idEquipo; }
            set { SetValue(ref this.idEquipo, value); }
        }

        public string TxtNombre
        {
            get { return this.nombreTorneo; }
            set { SetValue(ref this.nombreTorneo, value); }
        }

        public string TxtLocalidad
        {
            get { return this.localidad; }
            set { SetValue(ref this.localidad, value); }
        }

        public string TxtFecha
        {
            get { return this.fecha; }
            set { SetValue(ref this.fecha, value); }
        }

        public string TxtEquipo
        {
            get { return this.equipo; }
            set { SetValue(ref this.equipo, value); }
        }

        public object ListaDatos
        {
            get { return this.listaDatos; }
            set { SetValue(ref this.listaDatos, value); }
        }
        #endregion

        #region Comandos
        public ICommand AgregarComando
        {
            get
            {
                return new RelayCommand(AgregarMetodo);
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

        #region Métodos
        public async void AgregarMetodo()
        {
            
            await servicios.agregarEquipoTorneo(IDTorneo, TxtEquipo);
            this.IsRefreshing = true;
            await Task.Delay(1000);
            cargarDatos();
            this.IsRefreshing = false;
        }

        private async void EliminarMetodo()
        {
            await servicios.eliminarTorneo(IDTorneo);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async Task cargarDatos()
        {
            this.ListaDatos = await servicios.obtenerEquiposTorneo(IDTorneo);
        }
        #endregion
    }
}
