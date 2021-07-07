using Torneos.Vistas;
using Xamarin.Forms;

namespace Torneos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginVista())
            {
                BarBackgroundColor = Color.FromHex("#2C3E50"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
