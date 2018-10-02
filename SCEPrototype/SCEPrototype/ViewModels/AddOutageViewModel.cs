using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SCEPrototype.Interfaces;
using SCEPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace SCEPrototype.ViewModels
{
	public class AddOutageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;
        private IMobileApi _mobileApi;
        public DelegateCommand SubmitCommand { get; set; }

        private int _outageNumber;
        public int OutageNumber
        {
            get { return _outageNumber; }

            set { SetProperty(ref _outageNumber, value); RaisePropertyChanged(); }
        }

        private string _outageLocation;
        public string OutageLocation
        {
            get { return _outageLocation; }

            set { SetProperty(ref _outageLocation, value); RaisePropertyChanged(); }
        }

        private int _customersImpacted;
        public int CustomersImpacted
        {
            get { return _customersImpacted; }

            set { SetProperty(ref _customersImpacted, value); RaisePropertyChanged(); }
        }

        private string _outageStartTime;
        public string OutageStartTime
        {
            get { return _outageStartTime; }

            set { SetProperty(ref _outageStartTime, value); RaisePropertyChanged(); }
        }

        private string _outageType;
        public string OutageType
        {
            get { return _outageType; }

            set { SetProperty(ref _outageType, value); RaisePropertyChanged(); }
        }

        private string _outageReasoning;
        public string OutageReasoning
        {
            get { return _outageReasoning; }

            set { SetProperty(ref _outageReasoning, value); RaisePropertyChanged(); }
        }

        private bool _outageResolved;
        public bool OutageResolved
        {
            get { return _outageResolved; }

            set { SetProperty(ref _outageResolved, value); RaisePropertyChanged(); }
        }


        public AddOutageViewModel(INavigationService navigationService, IMobileApi mobileApi, IUnityContainer unityContainer)
            : base(navigationService)
        {

            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "Add New Outage";

            _mobileApi = mobileApi;

            SubmitCommand = new DelegateCommand(AddOutage);

        }

        private async void AddOutage()
        {

            Outage outage = new Outage()
            {

                OutageNumber = _outageNumber,
                OutageLocation = _outageLocation,
                CustomersImpacted = _customersImpacted,
                OutageStartTime = _outageStartTime,
                OutageReasoning = _outageReasoning,
                OutageResolved = false
            };

            //   await App.MobileService.GetTable<Borrower>().InsertAsync(borower);
            await _mobileApi.InsertOutage(outage);

            await _navigationService.NavigateAsync("CurrentOutages");

        }
    }
}
