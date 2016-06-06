using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using DataAccess.DAL;
using System.Linq;
using System.Collections.Generic;

namespace DataAccessAndroid
{
    [Activity(Label = "L2Ch3.DroidGUI", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class Activity1 : Activity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            ImageView logo = FindViewById<ImageView>(Resource.Id.imageView1);
            logo.SetImageResource(Resource.Drawable.logo);
            Button checkIngr = FindViewById<Button>(Resource.Id.CheckIngrButton);
			Button preferences = FindViewById<Button> (Resource.Id.userPreferencesButton);


			//Set User Preferences and store in a Database
			preferences.Click += delegate {
				StartActivity(typeof(PreferencesActivity));
			};

            checkIngr.Click += delegate
            {
                StartActivity(typeof(CheckDataActivity));
            };


        }



    }

}



