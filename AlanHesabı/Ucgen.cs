namespace AlanHesabı
{
    
    public class Ucgen : KenarliSekil
    {
        protected double kenar1;
        protected double kenar2;
        protected double kenar3;
        public Ucgen(double kenar1,double kenar2,double kenar3)
        {
            this.kenar1  = kenar1;
            this.kenar2 = kenar2;
            this.kenar3 = kenar3;
        }

        public override double Alan()
        {
            double cevre = this.Cevre()/2;
            return Math.Sqrt(cevre*(cevre - kenar1)*(cevre - kenar2)*(cevre - kenar3));
        }

        public override double Cevre()
        {
            return kenar1+kenar2+kenar3;
        }
        protected double Alan(double kenar1,double kenar2,double kenar3)
        {
            double cevre = this.Cevre(kenar1,kenar2,kenar3)/2;
            return Math.Sqrt(cevre*(cevre - kenar1)*(cevre - kenar2)*(cevre - kenar3));
        }
        protected double Cevre(double kenar1,double kenar2,double kenar3)
        {
            return kenar1+kenar2+kenar3;
        }
    }
}