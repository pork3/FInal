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
    public static class ExtensionMethods
    {
        public static bool Contains(this string conString, string toCheck, StringComparison comp)
        {
            return (conString.IndexOf(toCheck, comp) >= 0);

        }
    }
}