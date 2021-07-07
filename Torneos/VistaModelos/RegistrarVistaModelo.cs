using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Torneos.VistaModelos
{
    public class RegistrarVistaModelo : BaseVistaModelo
    {
        #region Atributos
        public string correo;
        public string pass;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        private string email;
        #endregion

        #region Propiedades
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

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Comandos
        public ICommand ComandoRegistrar
        {
            get
            {
                return new RelayCommand(MetodoRegistrar);
            }
        }
        #endregion

        #region Métodos
        private async void MetodoRegistrar()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                //await Application.Current.MainPage.DisplayAlert(
                  //  "Error",
                    //"You must enter an email.",
                    //"Accept");
                //return;
            }

            if (string.IsNullOrEmpty(this.pass))
            {
                //await App.Current.MainPage.DisplayAlert(
                  //  "Error",
                    //"You must enter a password.",
                    //"Accept");
                //return;
            }
           

            string WebAPIkey = "AIzaSyCCP89 - wlLVv_zoB4qLimW429Qz5JWVKEg";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(txtCorreo.ToString(), txtPass.ToString());
                string gettoken = auth.FirebaseToken;

                await App.Current.MainPage.Navigation.PushModalAsync(new LoginVista());
            }
            catch (Exception ex)
            {
                //await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
        #endregion

        #region Constructor
        public RegistrarVistaModelo()
        {
            IsEnabledTxt = true;
        }
        #endregion




    }
}
