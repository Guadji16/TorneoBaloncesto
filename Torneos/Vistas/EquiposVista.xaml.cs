using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torneos.Modelos;
using Torneos.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Torneos.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquiposVista : ContentPage
    {
        public EquiposVista()
        {
            InitializeComponent();
            BindingContext = new EquiposVistaModelo();
        }

        public async void EquipoColeccion_ItemSelect(object sender, SelectionChangedEventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DetallesEquipoVista(e.CurrentSelection.FirstOrDefault() as EquipoModelo));
        }
    }
        
}