using Torneos.Modelos;
using Torneos.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Torneos.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesEquipoVista : ContentPage
    {
        public DetallesEquipoVista()
        {
            InitializeComponent();
            BindingContext = new DetallesEquipoVistaModelo();
        }

        public DetallesEquipoVista(EquipoModelo _equipo)
        {
            InitializeComponent();
            BindingContext = new DetallesEquipoVistaModelo(_equipo);
        }
    }
}