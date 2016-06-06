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

namespace DataAccessAndroid
{
    public class TideAdapter : BaseAdapter<Tide> 
    {
        List<Tide> items;
        Activity tcontext;

        public TideAdapter(Activity a, List<Tide> i)
        {
            items = i; // string array
            tcontext = a;// activity
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override Tide this[int position]
        {
            get {return items[position]; } // indexer
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public string HiLoConverter(string s)
        {
            if (s.Contains("H"))
            {
                s = "High";
                
            }
            else if (s.Contains("L"))
            {
                s = "Low";
                 
            }
            return  s; 
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = tcontext.LayoutInflater.Inflate(Resource.Layout.TideView, null, false);
            }
            view.FindViewById<TextView>(Resource.Id.DayText).Text = items[position].City; 
            

            view.FindViewById<TextView>(Resource.Id.DateTimeText).Text = items[position].Day + " " + items[position].Date +" " + items[position].Time;

            view.FindViewById<TextView>(Resource.Id.FeetPredictionText).Text = items[position].Feet + "ft " +  HiLoConverter(items[position].HiLo); 

            return view;
        }



    }
}