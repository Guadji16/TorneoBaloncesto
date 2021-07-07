using Torneos.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Torneos.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TorneoVista : ContentPage
    {
        public TorneoVista()
        {
            InitializeComponent();
            BindingContext = new TorneoVistaModelo();
        }
    }
}