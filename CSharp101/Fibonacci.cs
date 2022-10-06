namespace CSharp101 
{
    public class Fibonacci {

        public double FibonacciAvarage(int depth,int counter = 0,int previous = 0 , int previous2 = 0,int sum = 0)
        {
            sum += previous+previous2; 
            if(counter == depth){
               
                return (sum)/(double)depth;    
            } 
            if(counter == 0) return FibonacciAvarage(depth,counter+1,0,1,0);
            if(counter == 1 ) {
                
                return FibonacciAvarage(depth,counter+1,0,1,1);
            }
            
            return FibonacciAvarage(depth,counter+1,previous2,previous+previous2,sum);
        } 
    }
}