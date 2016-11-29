using Newtonsoft.Json.Linq;
using System.Linq;


namespace App5
{
    public class Waluty //klasa na pobranie wartosci z api, tu nie ma hermetyzacji, warto uzupelnic
    {
        public string exUrl = "http://api.fixer.io/2016-11-28?base=PLN&symbols=USD"; //stworzenie linku
        public string kursWymiany = "";

        public Waluty()
        {

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(exUrl);

                var stuff = JObject.Parse(json);


                foreach (var rate in stuff["rates"].Cast<JProperty>())
                {
                    kursWymiany = rate.Value.ToString();
                }
            }

        }
    }
}