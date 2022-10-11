
using AtmApp.Service.Concrete;
using CrossCuttingConcerns.Logging;

namespace AtmApp
{
    class Program
    {
        static void Main(string[] args)
        {
          AtmApp atm = new AtmApp(new UserService(),new Logger());
          atm.Start();
        }
    }
}
