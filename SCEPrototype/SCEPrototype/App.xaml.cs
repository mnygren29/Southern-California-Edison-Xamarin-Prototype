using Prism;
using Prism.Ioc;
using SCEPrototype.ViewModels;
using SCEPrototype.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using SCEPrototype.Interfaces;
using SCEPrototype.Services;
using Microsoft.WindowsAzure.MobileServices;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SCEPrototype
{
    public partial class App : PrismApplication
    {
        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient MobileService =
    new MobileServiceClient(
    "https://scemobileappeasytables.azurewebsites.net"
);


        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMobileApi, MobileApi>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<BaseTabbedPage>();
            containerRegistry.RegisterForNavigation<CurrentOutages>();
            containerRegistry.RegisterForNavigation<AddOutage>();
            containerRegistry.RegisterForNavigation<FieldCrewUpdateForm>();
        }
    }
}
