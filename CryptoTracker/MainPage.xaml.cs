using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var client = new RestClient("https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;XMR;DASH;LTC");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", "D6F273DA-AFD9-4542-ABE6-89D9179D47FE");
            IRestResponse response = client.Execute(request);
        }
    }
}
