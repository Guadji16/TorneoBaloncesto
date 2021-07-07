using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Torneos.Vistas;
using Xamarin.Forms;
using Torneos.VistaModelos;

namespace Torneos.VistaModelos
{
    public class MenuVistaModelo : BaseVistaModelo
    {
        #region Constructor
        public MenuVistaModelo()
        {

        }
        #endregion

        #region Atributos

        #endregion

        #region Propiedades

        #endregion

        #region Comandos
        public ICommand TorneoVistaComando
        {
            get
            {
                return new RelayCommand(TorneoVistaMetodo);
            }
        }
        public ICommand MostrarTorneosVistaComando
        {
            get
            {
                return new RelayCommand(MostrarTorneosVistaMetodo);
            }
        }
        public ICommand EquiposVistaComando
        {
            get
            {
                return new RelayCommand(EquiposVistaMetodo);
            }
        }

        
        #endregion

        #region Metodos
        private async void TorneoVistaMetodo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TorneoVista());
        }

        private async void MostrarTorneosVistaMetodo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MostrarTorneosVista());
        }

        private async void EquiposVistaMetodo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EquiposVista());
        }
        #endregion
    }
}
