using Torneos.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Torneos.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuVista : ContentPage
    {
        public MenuVista()
        {
            InitializeComponent();
            BindingContext = new MenuVistaModelo();
        }
    }
}