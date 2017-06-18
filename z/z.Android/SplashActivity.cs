using Android.App;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace z.Droid
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Thread.Sleep(10000); // Simulate a long loading process on app startup.
            StartActivity(typeof(MainActivity)); // Тут указать нашу главную Activity
        }
    }
}