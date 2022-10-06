namespace AlanHesabı 
{
    public class Dikdortgen : KenarliSekil
    {
         
         protected double kenar1 {get; set;}
         protected double kenar2 {get; set;}
         public Dikdortgen(double kenar1,double kenar2){
            this.kenar1 = kenar1;
            this.kenar2 = kenar2;
         }

        public override double Alan()
        {
            return kenar1 * kenar2;
        }

        public override double Cevre()
        {
            return (kenar1+kenar2)*2;
        }
    }
}