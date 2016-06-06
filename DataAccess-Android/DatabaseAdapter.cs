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
using DataAccess.DAL;

namespace DataAccessAndroid
{
    [Activity(Label = "DatabaseAdapter")]
    public class DatabaseAdapter : BaseAdapter<Vegan>
     {
        List<Vegan> vItems;
        Activity vContext;
        private int RowLay;

        public DatabaseAdapter(Activity a, List<Vegan> i)
        {
            vItems = i; // string array
            vContext = a;// activity
        }

        public DatabaseAdapter(Activity a, int r, List<Vegan> i)
        {
            vItems = i; // string array
            vContext = a;// activity
            RowLay =r;
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override Vegan this[int position]
        {
            get { return vItems[position]; } // indexer
        }

        public override int Count
        {
            get { return vItems.Count; }
        }

        
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = vContext.LayoutInflater.Inflate(Resource.Layout.DatabaseRow, null, false);
            }
            view.FindViewById<TextView>(Resource.Id.textView1).Text = vItems[position].Name + " is " + vItems[position].isVegan;

            return view;
        }



    }
}