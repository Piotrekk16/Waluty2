using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace App5
{
    [Activity(Label = "App5", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        WalutyInfo info = new WalutyInfo(); //obiekt sluzacy za automatyczne napisywanie pola wartosc i wyliczenie wartosci

        //pola tekstowe
        TextView Wartosc;
        TextView IloscWaluty1;

        //konstruktor - może być zbędny, ale przydatny na jakieś opiekowanie się zmianą wartosci
        public MainActivity()
        {
            info.ZmianaIosci += (sender, e) => {
                Wartosc.Text = info.Wartosc.ToString();                
            };
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main); //odwołanie się to wyglądu Main

            Wartosc = FindViewById<TextView>(Resource.Id.Wartosc); //wyszukanie odpowiedniego pola w Main

            var w1 = FindViewById<TextView>(Resource.Id.IloscWaluty1);
            w1.AfterTextChanged += (sender, e) => {
                info.Wal1 = Parse(w1);
            };
        }

        static decimal Parse(TextView field) //parsowanie pola tekstowego i łapanie wyjątka
        {
            if (field.Text == "")
                return 0m;
            try
            {
                return Convert.ToDecimal(field.Text);
            }
            catch (Exception e)
            {
                field.Text = "";
                return 0m;
            }
        }
    }
}

