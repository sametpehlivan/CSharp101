namespace AlanHesabı
{
    public class DikdortgenPrizma : Dikdortgen, IUcBoyutlu
    {
        double kenar3 ;
        public DikdortgenPrizma(double kenar1, double kenar2,double kenar3) : base(kenar1, kenar2)
        {
            this.kenar3 = kenar3;
        }
        public override double Cevre()
        {
            return base.Cevre()*2+4*kenar3;
        }
        public override double Alan()
        {
            return base.Alan()*2 + kenar1*kenar3*2 + kenar2*kenar3*2;
        }

        public double Hacim()
        {
            return base.Alan()*kenar3;
        }
    }
}