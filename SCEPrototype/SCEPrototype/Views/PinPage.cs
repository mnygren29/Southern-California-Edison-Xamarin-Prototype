using Prism.Navigation;
using SCEPrototype.Interfaces;
using SCEPrototype.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SCEPrototype.Views
{
    public class PinPage : ContentPage
    {
        Map map;

      //  private readonly INavigationService _navigationService;


        public PinPage()
        {
             
          
     
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(33.812092, -117.918976), Distance.FromMiles(3))); 

       

           var position = new Position(33.812092, -117.918976); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "DisneyLand",
                Address = "03815547-55e6-4717-a7bd-71b587e5fbc9"
                //Id= "03815547-55e6-4717-a7bd-71b587e5fbc9"
            };
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(34.050750, -118.081010),
                Label = "Southern California Edison",
                Address = "Rosemead, CA"
                
            });
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(34.092808, -118.328659),
                Label = "Hollywood",
                Address = "Hollywood California"
            });
            map.Pins.Add(pin);

            pin.Clicked += (object sender, EventArgs e) =>
            {
              


                var p = sender as Pin;

                Outage outage = new Outage()
                {
                    Id = p.Address,
                    OutageResolved = true
                };


                UpdateOutage(outage);


            };


            // create buttons
            var morePins = new Button { Text = "Add more pins" };
            morePins.Clicked += (sender, e) => {
                map.Pins.Add(new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(36.9641949, -122.0177232),
                    Label = "Boardwalk",
                    Address = "custom detail info"
                });
                map.Pins.Add(new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(36.9571571, -122.0173544),
                    Label = "Wharf",
                    Address = "custom detail info"
                });
                map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(36.9628066, -122.0194722), Distance.FromMiles(1.5)));

            };
            var reLocate = new Button { Text = "Re-center" };
            reLocate.Clicked += (sender, e) => {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(36.9628066, -122.0194722), Distance.FromMiles(3)));
            };
            var buttons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    morePins, reLocate
                }
            };

            // put the page together
            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    map,
                    buttons
                }
            };
        }
        public async void UpdateOutage(Outage outage)
        {
            try
            {

                var updateOutage = await App.MobileService.GetTable<Outage>().Where(p => p.Id == outage.Id)
                        .ToListAsync();

                foreach (var item in updateOutage)
                {
                    item.OutageResolved = outage.OutageResolved;

                   // await App.MobileService.GetTable<Outage>().UpdateAsync(item);
                }
                //  await _navigationService.NavigateAsync("FieldCrewUpdateForm");
                await App.Current.MainPage.DisplayAlert("Outages", "You will now be redirected to Outage Field Form Input!", "OK");
                await Navigation.PushAsync(new FieldCrewUpdateForm());
            }
            catch (Exception ex)
            {

            }
        }

    }
}


