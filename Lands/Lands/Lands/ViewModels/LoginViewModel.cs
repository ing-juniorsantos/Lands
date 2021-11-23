using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Services
        //private ApiService apiService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            //this.apiService = new ApiService();

            this.IsRemembered = true;
            this.IsEnabled = true;

            //this.Email = "jzuluaga55@hotmail.com";
            //this.Password = "123456";
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Digite correo", "Aceptar");
                //Languages.Error,
                //Languages.EmailValidation,
                //Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error","Digite contraseña","Aceptar");
                    //Languages.Error,
                    //Languages.PasswordValidation,
                    //Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            //var connection = await this.apiService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(
            //        Languages.Error,
            //        connection.Message,
            //        Languages.Accept);
            //    return;
            //}

            //var token = await this.apiService.GetToken(
            //    "http://landsapi1.azurewebsites.net",
            //    this.Email,
            //    this.Password);

            //if (token == null)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(
            //        Languages.Error,
            //        Languages.SomethingWrong,
            //        Languages.Accept);
            //    return;
            //}

            //if (string.IsNullOrEmpty(token.AccessToken))
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(
            //        Languages.Error,
            //        token.ErrorDescription,
            //        Languages.Accept);
            //    this.Password = string.Empty;
            //    return;
            //}

            //var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.Token = token;
            //mainViewModel.Lands = new LandsViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            if(this.Email != "junior" || this.Password != "1234")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrecto.", "Aceptar");
                this.IsRunning = false;
                this.IsEnabled = true;
                this.Password = string.Empty;
                return;    
            }

            await Application.Current.MainPage.DisplayAlert("Excelente", "Excelente", "Aceptar");

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
        }
        #endregion
    }
}
