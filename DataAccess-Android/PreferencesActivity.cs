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
using SQLite;
using DataAccess.DAL;
using System.Xml.Serialization;

namespace DataAccessAndroid
{
    [Activity(Label = "PreferencesActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]			
	public class PreferencesActivity : Activity

	{
		private List<string> UserPref;
        EditText UserEdit;
        string dbPath;
        ListView pListView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

            if (savedInstanceState ==null)
            {
                UserPref = new List<string>();
                UserPref.Add("Sugar");
                UserPref.Add("Palm Oil");
                UserPref.Add("High Fructose Corn Syrup");
                
                
            }
            else
            {
                UserPref = savedInstanceState.GetStringArray("items").ToList();
                
            }

            ///database stuff///
            dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "vegan.db3");
            using (Stream inStream = Assets.Open("vegan.db3"))
            using (Stream outStream = File.Create(dbPath))
                inStream.CopyTo(outStream);
            ///////////////
            

			SetContentView(Resource.Layout.Preferences);

            PreferencesAdapter adapter = new PreferencesAdapter(this, UserPref);
            UserEdit = FindViewById<EditText>(Resource.Id.searchtext);
            pListView = FindViewById<ListView>(Resource.Id.preferencesListView);
            TextView Label = FindViewById<TextView>(Resource.Id.AddLabel);
            Button AddtoNV = FindViewById<Button>(Resource.Id.AddButton1);
            
			pListView.Adapter = adapter;
            //// Edit Text event////

            AddtoNV.Click += delegate
            {
                string toast = string.Format("{0} has been added as non vegan", UserEdit.Text);

                Toast.MakeText(this, toast, ToastLength.Long).Show();

                UserPref.Add(UserEdit.Text);
                 

                using (var db = new SQLiteConnection(dbPath))
                {
                    db.Insert(new Vegan()
                        {
                            Name = UserEdit.Text,
                            isVegan = "Not Vegan",
                        });
                }

                UserEdit.Text = string.Empty;
                pListView.RequestLayout();
            
            };


       
		}


        void pListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            CheckedTextView chek = FindViewById<CheckedTextView>(Resource.Id.checkedTextView1);

            

            bool isChecked = chek.Checked;
            if (isChecked == true)
                isChecked = false;
            else isChecked = true;         
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutStringArray("items", UserPref.ToArray());
            
        }

        
	}
}

