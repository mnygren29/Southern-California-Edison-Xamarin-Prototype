using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Webkit;
using Microsoft.WindowsAzure.MobileServices;
using Prism;
using Prism.Ioc;
using SCEPrototype.Droid;
using SCEPrototype.Infrastructure;
using SCEPrototype.Interfaces;
using System;
using System.Threading.Tasks;

namespace SCEPrototype.Droid
{
    [Activity(Label = "SCEPrototype", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        MobileServiceUser user;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            App.Init((IAuthenticate)this);
            LoadApplication(new App(new AndroidInitializer()));
        }

        public async Task<bool> AuthenticateAsync()
        {
            bool success = false;
            try
            {
                if (user == null)
                {
                    // The authentication provider could also be Facebook, Twitter, or Microsoft
                    user = await TodoItemManager.DefaultManager.CurrentClient.LoginAsync(this, MobileServiceAuthenticationProvider.MicrosoftAccount, Constants.ApplicationURL);
                    if (user != null)
                    {
                        CreateAndShowDialog(string.Format("You are now logged in - {0}", user.UserId), "Logged in!");
                    }
                }
                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex.Message, "Authentication failed");
            }
            return success;
        }

        public async Task<bool> LogoutAsync()
        {
            bool success = false;
            try
            {
                if (user != null)
                {
                    CookieManager.Instance.RemoveAllCookie();
                    await TodoItemManager.DefaultManager.CurrentClient.LogoutAsync();
                    CreateAndShowDialog(string.Format("You are now logged out - {0}", user.UserId), "Logged out!");
                }
                user = null;
                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex.Message, "Logout failed");
            }

            return success;
        }
        void CreateAndShowDialog(string message, string title)
        {
            var builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.SetNeutralButton("OK", (sender, args) => { });
            builder.Create().Show();
        }

    }



    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }

   

   
   
}

