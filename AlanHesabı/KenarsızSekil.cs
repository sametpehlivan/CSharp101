namespace AlanHesabı 
{
    
    public abstract class KenarsizSekil : IIkiBoyutlu
    {
        protected double pi = Math.PI;
        public abstract double Alan();
        public abstract double Cevre();
    }

}