namespace AlanHesabı 
{
    public class EskenarCokgenPrizma : EskenarCokgen, IUcBoyutlu
    {

        double yukseklik;
        public EskenarCokgenPrizma(double kenarUzunlugu,double yukseklik, int kenarSayisi) : base(kenarUzunlugu, kenarSayisi)
        {
            this.yukseklik = yukseklik;
        }
        public override double Alan()
        {
            return base.Alan() + base.kenarsayisi*kenarUzunlugu*yukseklik;
        }

        public double Hacim()
        {
            return base.Alan() * yukseklik;
        }
    }
}