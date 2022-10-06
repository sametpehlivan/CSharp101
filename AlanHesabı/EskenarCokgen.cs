namespace AlanHesabı
{
    public class EskenarCokgen :KenarliSekil, IIkiBoyutlu
    {
        protected double kenarUzunlugu;
        protected int kenarsayisi;
        public EskenarCokgen(double kenarUzunlugu,int kenarsayisi)
        {
            this.kenarUzunlugu = kenarUzunlugu;
            this.kenarsayisi = kenarsayisi;
        }
        public override double  Alan()
        {
            return (double)1/4*(this.kenarsayisi*this.kenarUzunlugu*this.kenarUzunlugu*(Math.Cos(Math.PI/this.kenarsayisi)/Math.Sin(Math.PI/this.kenarsayisi)));
        }


        public override double  Cevre()
        {
            return this.kenarsayisi * this.kenarUzunlugu;
        }

       
    }
}