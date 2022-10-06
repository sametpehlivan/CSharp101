namespace CSharp101 
{
    public static class SessizHarf
    {
        public static string isRepatConsonant(this string word)
        {
            char[] sessizHarfler={'z', 'y', 'v', 't', 'ş', 's', 'r', 'p', 'n', 'r', 'm', 'l', 'k', 'h', 'j', 'ğ', 'g', 'd', 'ç', 'c', 'b'}; 
            var wordArray = word.ToArray();
            bool flag = false;
            for(int i = 0; i < wordArray.Length; i++)
            {
                if(sessizHarfler.Contains(wordArray[i]) && i != wordArray.Length-1 )
                {
                    if(sessizHarfler.Contains(wordArray[i+1])) flag = true; 
                }
            }
            return flag.ToString();
        }
    }
}