using AtmApp.Entities;
using AtmApp.Service.Abstract;
using CrossCuttingConcerns.Logging;

namespace AtmApp
{
    public class AtmApp
    {
        IUserService _userService;
        ILogger _logger;
        User _user;
        public AtmApp(IUserService userService,ILogger logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public void Init()
        {
              _userService.Add(new User() 
            {
                Id = _userService.GenerateId(),
                UserName = "user1",
                 Password = "1234",
                Amount = 100
            });
            _userService.Add(new User()
            {
                Id = _userService.GenerateId(),
                UserName = "user2",
                Password = "1234",
                Amount = 0
            });
            _userService.Add(new User()
            {
                Id = _userService.GenerateId(),
                UserName = "user3",
                Password = "1234",
                Amount = 0
            });
        }
        public void Start()
        {
            Init();
            loginCheck:
            var result = LoginOrRegisterMenu();
            if (!result) goto loginCheck;
            Console.WriteLine("Bakiyeniz : "+_user.Amount);
            Console.WriteLine("işlem seçiniz :\nPara Yatırma (1)\nPara Çekme(2)\nGün Sonu bilgisi(3)");
            Console.Write("=> ");
            var islem = Console.ReadLine().Trim();
            double amount;
            switch(islem)
            {
                case "1":
                    Console.Write("Tutar giriniz : ");
                    amount = Math.Abs(Int64.Parse(Console.ReadLine()));
                    ParaIslem(amount,"PARAYATIR");
                break;
                case "2":
                    Console.Write("Tutar giriniz : ");
                    amount = Math.Abs(Int64.Parse(Console.ReadLine()));
                    ParaIslem(amount*(-1),"PARACEK");
                break;
                case "3":
                    foreach(var item in _logger.GetLogs())
                    {
                        Console.WriteLine(item.DateTime.ToString() + " Tarihinde: " + item.TypeName.ToUpper() + " işlemi gerçekleşrildi.İslem Sonucu: " + item.Message);
                    }
                break ;
                default:
                    Console.WriteLine("Gecersiz işlem");
                break;
            }
            Console.WriteLine("Kalan Bakiye: "+_user.Amount);
            Console.ReadLine();

        }
        public bool LoginOrRegisterMenu() 
        {
            Console.WriteLine("Kayıt için 'k' Giriş için 'g' ");
            Console.Write("=> ");
            var loginOrRegister = Console.ReadLine().Trim().ToLower();
            GetLoginOrRegisterInfo();
            bool result;
            if (loginOrRegister.Equals("k")){

                result =  Register(_user);
                string message = result ? "Kayıt Basrılı":"Kayıt İslemi Basarisiz";
                _logger.Log(_user.UserName,"Register",result.ToString().ToUpper(),message);
                return result;
            } 
            else if (loginOrRegister.Equals("g")) {
                result =  Login();
                string message = result ? "Giris Basrılı":"Giris İslemi Basarisiz";
                _logger.Log(_user.UserName,"Login",result.ToString().ToUpper(),message);
                return result;
            }
            else
            {
                Console.WriteLine("=> Geçersiz Giriş");
                return false;
            }
            
        }
          public void GetLoginOrRegisterInfo() 
        {
            Console.Write("Kullanıcı Adı : ");
            var userName = Console.ReadLine();
            Console.Write("Şifre : ");
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.Write("\n");
            _user = new User()
            {
                UserName = userName.Trim(),
                Password = pass
            };
         
        }
        public bool Register(User user)
        {
            user.Id = _userService.GenerateId();
            user.Amount = 0;
            bool result = _userService.Add(user);
            if (!result) Console.WriteLine("Kullanıcı Adı Mevcut");
            else Console.WriteLine("Kayıt başarılı");
            return result;
        }
        public bool Login() 
        {
            if(_userService.Get(u => u.UserName == _user.UserName) != null) 
            {
                var user = _userService.Get(u => u.UserName == _user.UserName && _user.Password == u.Password);
                if ( user != null)
                {   _user.Id = user.Id;
                    _user.Amount = user.Amount;
                    Console.WriteLine("Giriş Başarılı\n");
                    return true;
                }
                Console.WriteLine("Şifre yanlış gardaş, \n C:\\Users\\pc\\Desktop\\Angular Proje\\angular\\VotingApp\\VotingApp\\bin\\Debug\\net5.0 altında user.json var ona bak.\nBaktıktan sonra sil!!!\n");
                return false;

            }
            Console.WriteLine("Kullanıcı bulunamadı\n");
            return false;
        }
        public bool ParaIslem(double amount,string logicName)
        {
            bool result = false;
            string message = "";
            if(!(logicName.Equals("PARACEK") && _user.Amount < Math.Abs(amount)))
            {
                
                _user.Amount += amount; 
                var updateResult = _userService.Update(_user);
                if(updateResult != null){
                    message = logicName;
                    result  = true;
                } 
                else
                {
                    Console.WriteLine("Bilinmeyen bir hata Oluştu");
                    _user.Amount -= amount; 
                    message = "Bilinmeyen bir hata Oluştu";
                }
               
            }else
            {
                message ="Yetersiz Bakiye";
                Console.WriteLine("Yetersiz Bakiye");
            }
            _logger.Log(_user.UserName,logicName,result.ToString().ToUpper(),message);
            return result;

        }

    }
}