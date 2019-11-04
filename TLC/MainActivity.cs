using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Flurl.Http;
using System.Net;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Android.Net;
using Android.Content;
using System.Net.Http;
using System.Collections.Generic;
using Android.Webkit;

namespace TLC
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        string username;
        string password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            //Webview seems to have the best implementation, however the page won't load once I login
            var webView = FindViewById<WebView>(Resource.Id.webView);
            webView.SetWebViewClient(new HelloWebViewClient());
            WebSettings websettings = webView.Settings;
            websettings.JavaScriptEnabled = true;
            websettings.UserAgentString = "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.4) Gecko/20100101 Firefox/4.0";
            webView.LoadUrl("https://mytlc.bestbuy.com");
            


        }



        [Java.Interop.Export("ButtonClick")]
        public void SignIn(View v)
        {
           /* username = FindViewById<EditText>(Resource.Id.username).Text;
            password = FindViewById<EditText>(Resource.Id.password).Text;*/

           // ConnectToWebAsync(username, password);




        }

        public async Task ConnectToWebAsync(string username, string password)
        {
            /*WebClient wc = new WebClient();
            using (Stream st = wc.OpenRead("https://bbyfed.bestbuy.com/idp/SSO.saml2"))
            {
                using (StreamReader sr = new StreamReader(st, Encoding.UTF8))
                {
                    string html = sr.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(html);
                }
            }*/

            //Browser.OpenAsync("https://mytlc.bestbuy.com/", BrowserLaunchMode.SystemPreferred);


        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


    internal class HelloWebViewClient : WebViewClient
    {
        //Give the host application a chance to take over the control when a new URL is about to be loaded in the current WebView.  
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            view.LoadUrl(request.Url.ToString());
            return false;
        }
    }


}