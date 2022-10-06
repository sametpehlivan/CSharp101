namespace CSharp101 
{
   public static class IntegerIkiliToplami
   {
      public static int[] IntegerIkiliTopla(this int[] array)
      {

         var list = new List<int>();
         for(int i = 0;i<array.Length;i++)
         {
            if(i % 2 == 0 && i == array.Length-1) list.Add(array[i]);
            if(i % 2 == 1 )
            {
               if(array[i] == array[i-1]) list.Add((int)Math.Pow((double)(array[i]+array[i-1]),2));
               else list.Add(array[i]+array[i-1]);
            }   
         }
         return list.ToArray();

      }
   }
}