using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Torneos.Modelos;
using Torneos.Servicios;

namespace Torneos.VistaModelos
{
    class MostrarTorneosVistaModelo : BaseVistaModelo
    {
        #region Constructor
        public MostrarTorneosVistaModelo()
        {
            servicios = new FirebaseDB();
            torneoColeccion.Clear();
            torneoColeccion = servicios.obtenerTorneos();
        }
        #endregion

        #region Atributos
        private FirebaseDB servicios;
        private string categoriaSeleccionada;

        private ObservableCollection<TorneoModelo> torneoColeccion = new ObservableCollection<TorneoModelo>();
        private ObservableCollection<EquipoModelo> equipoColeccion = new ObservableCollection<EquipoModelo>();
        #endregion

        #region Propiedades
        public ObservableCollection<TorneoModelo> TorneoColeccion
        {
            set { SetValue(ref this.torneoColeccion, value); }
            get { return this.torneoColeccion; }
        }
        public ObservableCollection<EquipoModelo> EquipoColeccion
        {
            set { SetValue(ref this.equipoColeccion, value); }
            get { return this.equipoColeccion; }
        }

        public string CategoriaSeleccionada
        {
            set { SetValue(ref this.categoriaSeleccionada, value); 
            }
            get { return this.categoriaSeleccionada; }
        }

        #endregion

        #region Comandos

        #endregion

        #region Metodos
       
        #endregion
    }
}
