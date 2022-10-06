namespace CSharp101 
{
    public static class KarakterTersten 
    {
         public static List<string> ReverseWord(this List<string> input){
           return input.Select(s => {
                char[] array = s.ToCharArray();
               for(int i = 0; i < array.Length -1; i++){
                    char temp = array[i];
                    array[i] = array[i+1];
                    array[i+1] = temp;
               }
                return new string(array);
            }).ToList();
        }
    }
}