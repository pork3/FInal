using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.DAL;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;
using RestService;
using DAL;

namespace DataAccessAndroid
{
    [Activity(Label = "TideListActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class TideListActivity : ListActivity
    {
        string dbPath = null;
        string locPath = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            dbPath = dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "stocks.db3");
            locPath = dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "locations.db3");


            ViewTideList();
        }

        private void ViewTideList()
        {
            var dateTick = Intent.GetStringExtra("date");
            var location = Intent.GetStringExtra("city");
            string station = null;
            List<Tide> tide = null;
            List<TideLocations> tideloc = new List<TideLocations>();

            using (var getID = new SQLiteConnection(locPath))
            {
                var theID = getID.Table<TideLocations>().Select(t => t).Where(t => t.StationName.Contains(location)).ToList();
                foreach (var i in theID)
                    station += i.StationID;
                Console.WriteLine(station);
                TideRest tidesLoc = new TideRest();
                foreach (var y in tidesLoc.get7DayLowAndHigh(station, DateTime.Now))
                {
                    using (var db = new SQLiteConnection(dbPath))
                    {
                        foreach (var x in tide)
                        {
                            db.Insert(new Tide() { Date = dateTick, City = y.City, Day = y.Day, Feet = y.Feet, HiLo = y.HiLo, Time = y.Time });

                        }
                        Console.WriteLine(y.Date);
                        tide = (from t in db.Table<Tide>() select t).ToList();
                        //tide = db.Table<Tide>().Select(t => t).Where(t => t.City.Contains(y.City) && t.Date.StartsWith(y.Date)).ToList();
                        ListAdapter = new TideAdapter(this, tide);

                    }
                }



            }





        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            Intent = intent;
            ViewTideList();
        }


    }
}