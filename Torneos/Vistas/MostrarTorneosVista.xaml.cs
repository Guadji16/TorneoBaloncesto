using System.Linq;
using Torneos.Modelos;
using Torneos.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Torneos.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarTorneosVista : ContentPage
    {
        public MostrarTorneosVista()
        {
            InitializeComponent();
            BindingContext = new MostrarTorneosVistaModelo();
        }

        public async void TorneoColeccion_ItemSelect(object sender, SelectionChangedEventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DetallesTorneoVista(e.CurrentSelection.FirstOrDefault() as TorneoModelo));
        }


    }
}