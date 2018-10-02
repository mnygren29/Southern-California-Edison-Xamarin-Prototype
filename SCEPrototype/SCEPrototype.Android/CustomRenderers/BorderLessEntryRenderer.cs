using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SCEPrototype.CustomRenderers;
using SCEPrototype.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderLessEntryCustomRender), typeof(BorderLessEntryRenderer))]
namespace SCEPrototype.Droid.CustomRenderers
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class BorderLessEntryRenderer:EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }

        }

    }
#pragma warning restore CS0618 // Type or member is obsolete
}