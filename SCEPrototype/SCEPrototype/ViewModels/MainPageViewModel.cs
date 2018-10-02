using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SCEPrototype.Interfaces;
using SCEPrototype.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SCEPrototype.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IMobileApi _mobileApi;
        private readonly INavigationService _navigationService;
        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        bool authenticated = false;

        public ImageSource MyImageSource
        {
            get
            {
                //return ImageSource.FromResource("LoanDepotSplash.png");
                return Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("LoanDepotSplash.png") : ImageSource.FromFile("LoanDepotSplash.png");
            }
            set
            {
                RaisePropertyChanged();
            }
        }


        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }

        public MainPageViewModel(INavigationService navigationService, IMobileApi mobileApi)
            : base(navigationService)
        {

            this._navigationService = navigationService;

            Title = "User Login";
            _mobileApi = mobileApi;
            SubmitCommand = new DelegateCommand(GoToTabPage);
        
        }

        
        private async void GoToTabPage()
        {


            //app uses azure authentication using microsoft account. I disable this for the demo

            //try
            //{
            //    if (App.Authenticator != null)
            //    {
            //        authenticated = await App.Authenticator.AuthenticateAsync();
            //    }

            //    if (authenticated)
            //    {
            //      //  Application.Current.MainPage = new TodoList();
            //        await _navigationService.NavigateAsync($"{nameof(BaseTabbedPage)}");
            //    }
            //}
            //catch (InvalidOperationException ex)
            //{
            //    if (ex.Message.Contains("Authentication was cancelled"))
            //    {
            //       // messageLabel.Text = "Authentication cancelled by the user";
            //    }
            //}
            //catch (Exception)
            //{
            //  //  messageLabel.Text = "Authentication failed";
            //}


            //prototype login
            if (_username != "mnygren" || password != "secret")
            {
                await App.Current.MainPage.DisplayAlert("Invalid Login", "You have not entered a valid login. Please try again.", "OK");
                var guid = Guid.NewGuid().ToString();
            }
            else
            {
                await _navigationService.NavigateAsync($"{nameof(BaseTabbedPage)}");
            }

        }
    }
}
