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
using Android.Webkit;

namespace DataAccessAndroid
{
    [Activity(Label = "WebSearchActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class WebSearchActivity : Activity
    {
        private WebView vWebView;
        private EditText EditUrl;
        private WebClient vWebClient;
        private ProgressBar vProgress; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WebView);

            vWebClient = new WebClient();

            vWebClient.ProgChanged += (int state) =>
                {
                    if(state == 0)
                    {
                        vProgress.Visibility = ViewStates.Invisible;
                    }
                    else
                    {
                        vProgress.Visibility = ViewStates.Visible;
                    }
                };
            vWebView = FindViewById<WebView>(Resource.Id.veganWebView);
            EditUrl = FindViewById<EditText>(Resource.Id.txturl);
            vProgress = FindViewById<ProgressBar>(Resource.Id.progressBar);
            string item = Intent.GetStringExtra("item") ?? "not available";

            string url = string.Format("https://www.google.com/?gws_rd=ssl#q=is+{0}+vegan", item);

            vWebView.Settings.JavaScriptEnabled = true; //set up javascript
            vWebView.LoadUrl(url);
            vWebView.SetWebViewClient(vWebClient);

            EditUrl.Click += EditUrl_Click;

        }



        void EditUrl_Click(object sender, EventArgs e)
        {
            vWebClient.ShouldOverrideUrlLoading(vWebView, EditUrl.Text);
        }

        public class WebClient : WebViewClient
        {
            public delegate void ToggleProg(int state);
            public ToggleProg ProgChanged;

            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }

            public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
            {
                if(ProgChanged != null)
                {
                    ProgChanged.Invoke(1);//on
                }
                base.OnPageStarted(view, url, favicon);
            }

            public override void OnPageFinished(WebView view, string url)
            {
                if(ProgChanged !=null)
                {
                    ProgChanged.Invoke(0);//off
                }

                base.OnPageFinished(view, url);
            }
        }
    }
}