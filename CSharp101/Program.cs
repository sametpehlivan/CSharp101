using System.ComponentModel;
using System.Reflection;

namespace CSharp101 
{
    class CSharp101 {
         static void Main(string[] args)
        { 
            /*  
                ////////////  FibonacciToplam ortalama \\\\\\\\\\\\\\
                Fibonacci fibonacci = new Fibonacci();
                Console.WriteLine("Lütfen derinlik giriniz");
                int depth = Int32.Parse(Console.ReadLine());
                if(depth>0)Console.WriteLine(fibonacci.FibonacciAvarage(depth));
                else Console.WriteLine("hatalı giriş");    
            */
            /* 
                //////////////// Ucgen çizdirme \\\\\\\\\\\\\\\\\\\\\\\
                Triangle triangle = new Triangle();
                Console.WriteLine("Lütfen derinlik giriniz");
                int depth = Int32.Parse(Console.ReadLine());
                triangle.DrawTriangle(depth);
            */
            /*
                ////////////// daire çizdirme \\\\\\\\
                Daire d = new Daire();
                Console.WriteLine("Lütfen yerıçap giriniz");
                int radius = Int32.Parse(Console.ReadLine());
                d.DrawCircle(radius);
            */
            /* 
                //////////// Algoritma
                Algoritma,3 Algoritma,5 Algoritma,22 Algoritma,0
                Console.Write("Input : ");
                List<string> s = Console.ReadLine().Trim().Split(" ").ToList();
                
                s.DeleteIndex().WriteConsole();

            */
            /*
                /////////// Karakter Tersten Yazdırma
                Console.Write("Input : ");
                List<string> s = Console.ReadLine().Trim().Split(" ").ToList();
                s.ReverseWord().WriteConsole();
            */
            
            /*
                Integer Ikılı topla 
            
                Console.Write("Input: ");
                String[] s = Console.ReadLine().Trim().Split(" ");
                int[] values = s.Select(s => Int32.Parse(s)).ToArray();
                int[] toplam  = values.IntegerIkiliTopla(); 
                foreach(var i in toplam)
                {
                    Console.Write(i+" ");
                }
            */
            /* Mutlak Kare
                Console.Write("Input: ");
                String[] s = Console.ReadLine().Trim().Split(" ");
                int[] values = s.Select(s => Int32.Parse(s)).ToArray();
                int[] toplam  = values.MutlakKareal(67); 
                foreach(var i in toplam)
                {
                    Console.Write(i+" ");
                }
            */
           /*Karakter değiştirme
                Console.Write("Input: ");
                String[] input = Console.ReadLine().Trim().Split(" ");
                
                var  output = input.Select(i =>i.KarakterDegistir(0,i.Length-1)).ToList();
                
                foreach(var i in output)
                {
                    Console.Write(i+" ");
                }
            */
            /*
                Console.Write("Input: ");
                String[] input = Console.ReadLine().Trim().Split(" ");
                var  output = input.Select(i =>i.isRepatConsonant()).ToList();
                
                foreach(var i in output)
                {
                    Console.Write(i+" ");
                }
            */
        }
    }
                
        
}
