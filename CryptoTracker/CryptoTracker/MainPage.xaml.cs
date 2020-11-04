using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using CryptoTracker.Model;

namespace CryptoTracker
{
    public partial class MainPage : ContentPage
    {
        private string apiKey = "D6F273DA-AFD9-4542-ABE6-89D9179D47FE";
        private string baseImageUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        

        public MainPage()
        {
            InitializeComponent();
            CoinListView.ItemsSource = GetCoins();
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            CoinListView.ItemsSource = GetCoins();
        }

        private List<Coin> GetCoins()
        {
            List<Coin> coins;

            var client = new RestClient("https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;XMR;LTC");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);

            var response = client.Execute(request);

            coins = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coins)
            {
                if (!String.IsNullOrEmpty(c.Id_Icon))
                    c.Icon_Url = baseImageUrl + c.Id_Icon.Replace("-", "") + ".png";
                else
                    c.Icon_Url = "";
            }

            return coins;
        }
    }
}
