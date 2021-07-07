using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torneos.Vistas;
using Torneos.VistaModelos;
using Xamarin.Forms;

namespace Torneos
{
    public partial class LoginVista : ContentPage
    {
        public LoginVista()
        {
            InitializeComponent();
            BindingContext = new LoginVistaModelo();
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarVista());
        }
    }
}
