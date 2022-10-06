namespace CSharp101 
{
    public static class Algoritma 
    {
        public static List<string>  DeleteIndex(this List<string> input)
        {
            return input.Select(s => {
               
                try{
                    //Algoritma,3
                    int deleteIndex  =  Int32.Parse(s.Split(',')[1]); //
                    return s.Split(',')[0].Remove(deleteIndex,1); //
                }
                 catch
                {
                    return s.Split(',')[0];
                }
                
            } ).ToList();
          
           
        }
        public static void WriteConsole(this List<string> input)
        {
              Console.Write("\nOutput: ");
            foreach(string item in input){
                Console.Write(item+" ");
           }
        }
        /////////////// Karakter Tersen yazma
      
       
    } 

}