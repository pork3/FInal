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

namespace DataAccessAndroid
{
	public class PreferencesAdapter : BaseAdapter<string>
	{
		List<string>pItems;
		Context pContext;


		public PreferencesAdapter(Context context, List<string> items)
		{
			pItems = items;
			pContext = context;
		}

        public override int Count
        {
            get { return pItems.Count; }
        }

		public override long GetItemId (int position)
		{
			return position; 
		}

		//indexer

		public override string this[int position]
		{
			get {return pItems[position];}
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
			{
				View view = convertView;

                if (view == null)
                {
                    view = LayoutInflater.From(pContext).Inflate(Resource.Layout.PreferencesRow, null, false);
                }

                var prefSelect = view.FindViewById<CheckedTextView>(Resource.Id.checkedTextView1);
                prefSelect.Text = pItems[position];

                return view; 
			}
	}
}

