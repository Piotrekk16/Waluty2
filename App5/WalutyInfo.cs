using System;

namespace App5
{
    class WalutyInfo //klasa mo�e i zb�dna, ale gdzie� wypada umie�ci� mechanizm automatycznego wyliczenie warto�ci
    {
        decimal wal1;
        public decimal Wal1
        {
            get { return wal1; }
            set
            {
                if (wal1 != value)
                {
                    wal1 = value;
                    Zmiana();
                }
            }
        }

        

        private void Zmiana()
        {
            var h = ZmianaIosci;
            if (h != null)
                h(this, EventArgs.Empty);
        }

        
        public decimal Wartosc
        {
            get
            {
                Waluty www1 = new Waluty();
                return Wal1 * Convert.ToDecimal(www1.kursWymiany);
            }
        }

        public event EventHandler ZmianaIosci;
    }
}