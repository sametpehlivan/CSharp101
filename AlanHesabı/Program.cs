using System.ComponentModel;
using System.Reflection;
namespace AlanHesabı
{
    class AlanHesabı 
    {
        static void Main(string[] args)
        {
             ///////// Alan Hesaplama
                var sekiller = AlanHesaplamaProgram.GetSekil();
                
                Console.WriteLine(String.Concat(Enumerable.Repeat("*",85))+"\n");
                Console.WriteLine("Bir Sekil Seçiniz.Hesaplama Yapmak istediğiniz Şeklin İsmini girmeniz Yeterlidir.\n");
                Console.WriteLine(String.Concat(Enumerable.Repeat("*",85))+"\n");
                yenidenSekilAl:
                AlanHesaplamaProgram.ListSekil();
                var sekilInput = Console.ReadLine();
                var sekilIndex = AlanHesaplamaProgram.GetSekilIndex(sekilInput);
                if(sekilIndex == -1)
                {

                    Console.WriteLine("\nBöyle bir şekil Mevcut değil!!!\n");
                    goto yenidenSekilAl;
                }
                
                Console.WriteLine("\nSeçtiğiniz Şekil: " + AlanHesaplamaProgram.GetSekilName(sekilIndex));
                ConstructorInfo[] ctors = AlanHesaplamaProgram.GetSekilCtor(sekilIndex);
                
                //Parametre alma                
                foreach(var ctor in ctors){
                    
                    //Method Alma
                    object nesne = Activator.CreateInstance(sekiller[sekilIndex],AlanHesaplamaProgram.ReadParameters(ctor));
                    var methods = sekiller[sekilIndex].GetMethods();
                    Object[] parametersMethod = {};
                    foksiyonSec:
                    Console.WriteLine("Hesaplamak istediğiniz fonksiyonu seçiniz");
                    
                    
                    AlanHesaplamaProgram.ListMethod(methods);

                    string methodName = Console.ReadLine();
                    
                    int methodIndex = AlanHesaplamaProgram.GetMethodIndex(methods,methodName);
                    if(methodIndex  == -1)
                    {
                        Console.WriteLine("Böyle bir method bulunamadı");
                        goto foksiyonSec;
                    }
                    
                    Console.WriteLine(methodName?.ToUpper()+": "+ methods[methodIndex].Invoke(nesne,parametersMethod));
                }

                Console.ReadLine();
            
        }
    }
}
        
