using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torneos.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Torneos.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarVista : ContentPage
    {
        public RegistrarVista()
        {
            InitializeComponent();
            BindingContext = new RegistrarVistaModelo();
        }
    }
}