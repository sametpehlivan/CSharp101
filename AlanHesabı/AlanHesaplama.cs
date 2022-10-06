using System.ComponentModel;
using System.Reflection;

namespace AlanHesabı
{
 
    public static class AlanHesaplamaProgram
    {
        public static List<Type> GetSekil()
        {
            var type = typeof(ISekil);
            return  AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !(p.IsInterface || p.IsAbstract))
                .ToList();
        }
        public static void ListSekil()
        {
                foreach(var sekil in AlanHesaplamaProgram.GetSekil())
                {
                    Console.WriteLine("==> "+sekil?.FullName.Split(".")[1]);
                }
        }
       
        public static int GetSekilIndex(string sekilInput)
        {
            ///Sekil bilgisi alma
            return AlanHesaplamaProgram.GetSekil().Select(s => s?.FullName.Split(".")[1].Trim().ToLower()).ToList().IndexOf(sekilInput.Trim().ToLower());     
               
        }
        public static  ConstructorInfo[] GetSekilCtor(int index)
        {
           return AlanHesaplamaProgram.GetSekil()[index].GetConstructors();
        }
        public static string GetSekilName(int index)
        {
            return AlanHesaplamaProgram.GetSekil()[index].FullName.Split(".")[1].ToUpper();
        }
        public static void ListMethod(MethodInfo[] methods)
        {
            foreach(var method in methods)
                    {
                      if(! typeof(object).GetMethods().Select(m => m.Name).Contains(method.Name))
                      {
                        Console.WriteLine("==> "+method.Name);
                      }
                    }
        }
        public static Object[] ReadParameters(ConstructorInfo ctor)
        {
            List<Object> parameters = new List<Object>(); 
            foreach(var item in ctor.GetParameters())
                    {
                        
                        kenarAl:
                        var kenar = Activator.CreateInstance(item.ParameterType);
                        Console.WriteLine($"{item.Name.ToUpper()}  için  değer giriniz ({item.ParameterType.ToString().ToUpper().Split(".")[1]}) :");
                        var foksiyonIsim = Console.ReadLine();
                        foksiyonIsim = foksiyonIsim.Replace(".",",");
                    
                        try
                        {
                            kenar = TypeDescriptor.GetConverter(item.ParameterType).ConvertFromString(foksiyonIsim);
                        }catch
                        {
                            Console.WriteLine("Değer bilgisi doğru girdiğinize emin olunuz");
                            goto kenarAl;
                        }

                        
                        //a = Convert.ChangeType(s, item.ParameterType);
                        parameters.Add(kenar);
                        
                        
                    }
            return parameters.ToArray();
        }
        public static int GetMethodIndex(MethodInfo[] methods,string methodName)
        {
           return  methods.Select(m => m?.Name.ToLower().Trim()).ToList().IndexOf(methodName?.ToLower().Trim());
        }
         
    }


}