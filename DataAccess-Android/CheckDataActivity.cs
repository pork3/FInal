using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using DataAccess.DAL;
using SQLite;

namespace DataAccessAndroid
{
    [Activity(Label = "CheckDataActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class CheckDataActivity : Activity
    {
        string dbPath;
        List<Vegan> vList;
        private DatabaseAdapter vAdapter;
        EditText vSearch;
        ListView vListView;
        TextView CantFind;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Database);
            vSearch = FindViewById<EditText>(Resource.Id.addedit);
            CantFind = FindViewById<TextView>(Resource.Id.cantfindText);
            vListView = FindViewById<ListView>(Resource.Id.listView1);
            dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "vegan.db3");
            vListView.RequestLayout();
            // "edittext or search functionality etc//
            vSearch.TextChanged += vSearch_TextChanged;


            using (Stream inStream = Assets.Open("vegan.db3"))
            using (Stream outStream = File.Create(dbPath))
                inStream.CopyTo(outStream);

            

            using (var db = new SQLiteConnection(dbPath))
            {
                vList = (from v in db.Table<Vegan>() select v).ToList();

            }
            vAdapter = new DatabaseAdapter(this, vList);
            vListView.Adapter = vAdapter;

            CantFind.Click += CantFind_Click;


        }

        void CantFind_Click(object sender, EventArgs e)
        {
            var activity = new Intent(this, typeof(WebSearchActivity));
            activity.PutExtra("item", vSearch.Text.ToString());
            StartActivity(activity);
        }

        void vSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
           
            List<Vegan> searchItem = (from v in vList
                                      where v.Name.Contains(vSearch.Text, StringComparison.OrdinalIgnoreCase)
                                      select v).ToList();

            vAdapter = new DatabaseAdapter(this,Resource.Layout.DatabaseRow, searchItem);
            vListView.Adapter = vAdapter;

            CantFind.Text = string.Format("Cant find {0}, click here!", vSearch.Text);

        }

       
        // extension method for linq contains to help ignore case 




    }
}

        