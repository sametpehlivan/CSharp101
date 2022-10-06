namespace AlanHesabı 
{
    public class UcgenPrizma : Ucgen, IUcBoyutlu
    {
        double kenar4;
        public UcgenPrizma(double kenar1, double kenar2, double kenar3, double kenar4) : base(kenar1, kenar2, kenar3)
        {
        }
        public override double Cevre()
        {
            return base.Cevre()*2 + kenar4*3;
        }
        public override double Alan()
        {
            return base.Alan() + kenar1*kenar4 + kenar2*kenar4 + kenar3*kenar4;
        }
        public double Hacim()
        {
            return base.Alan()*kenar4;
        }
    }
}