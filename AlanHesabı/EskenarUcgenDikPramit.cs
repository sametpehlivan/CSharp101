namespace AlanHesabı
{
    public class EskanarUcgenDikPramit : Ucgen, IUcBoyutlu
    {
        double kenar4;
    
        public EskanarUcgenDikPramit(double kenar1, double kenar4) : base(kenar1, kenar1, kenar1)
        {
            this.kenar4 = kenar4;
            
        }
        private double Yukseklik()
        {
            return  Math.Sqrt((Math.Pow(kenar4,2)-(Math.Pow(kenar1,2)/3)));
        }
        public double Hacim()
        {
            return this.Alan() * this.Yukseklik()*(1/3);
        }
        public override double Alan()
        {
            return base.Alan() + 3 * this.Alan(kenar1,kenar4,kenar4);
        }
        public override double Cevre()
        {
            return base.Cevre()+ 3 * kenar4;
        }

    }
}