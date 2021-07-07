using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torneos.Modelos;
using Torneos.Servicios;
using Torneos.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Torneos.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesTorneoVista : ContentPage
    {
        public DetallesTorneoVista()
        {
            InitializeComponent();
            BindingContext = new DetallesTorneoVistaModelo();
        }

        public DetallesTorneoVista(TorneoModelo _torneo)
        {
            InitializeComponent();
            BindingContext = new DetallesTorneoVistaModelo(_torneo);
           
            
        }
    }
}