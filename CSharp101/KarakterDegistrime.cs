namespace CSharp101 
{
    public static class KarakterDegistirme 
    {
        public static string KarakterDegistir(this string word,int first,int last)
        {
            var wordArray = word.ToArray();
            char temp = wordArray[first];
            wordArray[first] = wordArray[last];
            wordArray[last] = temp;
            return new string(wordArray); 
        }
    }
}