using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SCEPrototype.Interfaces;
using SCEPrototype.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace SCEPrototype.ViewModels
{
	public class CurrentOutagesViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;

        public DelegateCommand SearchCommand { get; set; }
       
        public ObservableCollection<Outage> Outages
        {
            get { return _Items; }
            set
            {
                _Items = value;
                RaisePropertyChanged();
            }
        }


        private IMobileApi _mobileApi;

       // public ICommand GetBorrowerDetailsCommand => new Command<Borrower>(async (item) => await GetBorrowerDetailsAsync(item));

        private ObservableCollection<Outage> _Items;

        public CurrentOutagesViewModel(INavigationService navigationService, IMobileApi mobileApi, IUnityContainer unityContainer)
            : base(navigationService)
        {
            Outages  = new ObservableCollection<Outage>();

            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "Current Outages";

            _mobileApi = mobileApi;

             LoadOutagesAsync();
            _navigationService = navigationService;
        }

        public async void LoadOutagesAsync()
        {

            var outages = await _mobileApi.GetOutages();
            foreach (var outage in outages)
            {
                _Items.Add(outage);
            }
            Outages = _Items;
            RaisePropertyChanged("Outages");
        }
        

        //private async Task GetBorrowerDetailsAsync(Borrower borrower)
        //{

        //    var navigationParamaters = new NavigationParameters();
        //    navigationParamaters.Add("quotedetail", borrower.BorrowerName);

        //    await _navigationService.NavigateAsync("BorrowerDetails", navigationParamaters);
        //}
    }
}

