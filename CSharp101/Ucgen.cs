

namespace CSharp101 
{
    public class Triangle {

        public void DrawTriangle(int baseLength)
        {
           if(baseLength%2 == 0) this.DrawRightTriangle(baseLength);
           else this.DrawEquilateralTriangle(baseLength*2-1);
        } 
        private void DrawEquilateralTriangle(int baseLength,int count = 0){
             if(count == baseLength) return;
             if(count % 2 == 0) Console.Write(String.Concat(Enumerable.Repeat(" ",(baseLength-(count+1))/2))+String.Concat(Enumerable.Repeat("*",count+1))+String.Concat(Enumerable.Repeat("",(baseLength-(count+1))/2))+ "\n");
             DrawEquilateralTriangle(baseLength,count+1);
        }
        
        private void DrawRightTriangle(int baseLength,int count = 0){
             if(count == baseLength) return; 
             Console.Write(String.Concat(Enumerable.Repeat("*",count+1))+ "\n");
             DrawRightTriangle(baseLength,count+1);
        }
    }
}