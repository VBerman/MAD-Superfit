using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.MyRenderers;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
//change entry strip
[assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]
namespace Android.MyRenderers
{   

    class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(Graphics.Color.White);

        }
    }
}