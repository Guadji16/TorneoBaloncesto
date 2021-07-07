using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Torneos.Vistas;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Torneos.VistaModelos
{
    public class LoginVistaModelo : BaseVistaModelo
    {
        #region Atributos
        public string correo;
        public string pass;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Properties
        public string txtCorreo
        {
            get { return this.correo; }
            set { SetValue(ref this.correo, value); }
        }

        public string txtPass
        {
            get { return this.pass; }
            set { SetValue(ref this.pass, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }


        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Comandos
        public ICommand ComandoEntrar
        {
            get
            {
                return new RelayCommand(MetodoEntrar);
            }
        }
        #endregion

        #region Métodos
        public async void MetodoEntrar()
        {
            if (string.IsNullOrEmpty(this.correo))
            {
               // await Application.Current.MainPage.DisplayAlert(
                 //   "Error",
                  //  "You must enter an email.",
                   // "Accept");
               // return;
            }
            if (string.IsNullOrEmpty(this.pass))
            {
               // await Application.Current.MainPage.DisplayAlert(
                 //   "Error",
                  //  "You must enter a password.",
                  //  "Accept");
               // return;
            }

            string WebAPIkey = "AIzaSyCCP89-wlLVv_zoB4qLimW429Qz5JWVKEg";


            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(txtCorreo.ToString(), txtPass.ToString());
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);

                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);

                await Application.Current.MainPage.Navigation.PushAsync(new MenuVista());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Usuario o contraseña incorrectos", "OK");
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(20);
            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;



        }
        #endregion

        #region Constructor
        public LoginVistaModelo()
        {
            this.IsEnabledTxt = true;
        }
        #endregion
    }
}
