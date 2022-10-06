namespace CSharp101
{
    public static class MutlakKareAlma
    {
        public static int[] MutlakKareal(this int[] array,int a)
        {
            int[] result = {0,0};
            foreach(int item in array)
            {
                var fark = a - item ;
                if(item <= a ) result[0] += fark;
                else result[1] += (int)Math.Pow(Math.Abs(fark),2);
            }
            return result;
        }
    }
}