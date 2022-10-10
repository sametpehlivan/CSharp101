using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VotingApp.Extensions
{
    public static class NormalizeExtension
    {
    
            public static string CharFormalization(this string name)
            {
                name = name.Replace("ü", "u")
                            .Replace("ö", "o")
                            .Replace("Ü", "U")
                            .Replace("Ö", "O")
                            .Replace("İ", "I")
                            .Replace("ı", "i")
                            .Replace("ç", "c")
                            .Replace("Ç", "C")
                            .Replace("Ş", "S")
                            .Replace("ş", "s")
                            .Replace("Ğ", "G")
                            .Replace("Â", "A")
                            .Replace("â", "a")
                            .Replace("Î", "I")
                            .Replace("î", "i")
                            .Replace("ğ", "g")
                            .Replace("-", " ");


                name = Regex.Replace(name, @"\s+", "-");
                return Regex.Replace(name, @"[^0-9a-zA-Z-]+", "");
            }
        
    }
}
