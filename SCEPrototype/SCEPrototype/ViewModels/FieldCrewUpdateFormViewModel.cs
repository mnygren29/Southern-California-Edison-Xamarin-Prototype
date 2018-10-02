using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SCEPrototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity;

namespace SCEPrototype.ViewModels
{
    public class FieldCrewUpdateFormViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;
        private IMobileApi _mobileApi;
        public DelegateCommand SubmitCommand { get; set; }

        //PropertyMinimumDate = DateTime.Now.AddHours(-24);

        public DateTimeOffset MinYear
        {
            get { return new DateTime(2018, 1, 1); }
        }

        public DateTimeOffset MaxYear
        {
            get { return new DateTime(2020, 12, 31); }
        }

        private DateTime _arrivalTime;
        public DateTime ArrivalTime
        {
            get { return _arrivalTime; }

            set { SetProperty(ref _arrivalTime, value); RaisePropertyChanged(); }
        }

        private DateTime _estimatedRestorationTime;
        public DateTime EstimatedRestorationTime
        {
            get { return _estimatedRestorationTime; }

            set { SetProperty(ref _estimatedRestorationTime, value); RaisePropertyChanged(); }
        }


        private bool _restorationComplete;
        public bool RestorationComplete
        {
            get { return _restorationComplete; }

            set { SetProperty(ref _restorationComplete, value); RaisePropertyChanged(); }
        }

        private string _delayReason;
        public string DelayReason
        {
            get { return _delayReason; }

            set { SetProperty(ref _delayReason, value); RaisePropertyChanged(); }
        }


        public FieldCrewUpdateFormViewModel(INavigationService navigationService, IMobileApi mobileApi, IUnityContainer unityContainer)
            : base(navigationService)
        {

            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "Field Crew Outage Update";

            _mobileApi = mobileApi;

            SubmitCommand = new DelegateCommand(SubmitFieldWorkOrder);

        }


        private async void SubmitFieldWorkOrder()
        {
            await App.Current.MainPage.DisplayAlert("Field Work Order", "Thank you for submitting your work order!", "OK");
          
            await _navigationService.NavigateAsync("CurrentOutages");
        }
    }
}
