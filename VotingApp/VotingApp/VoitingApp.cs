using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingApp.Extensions;
using VotingApp.Service.Abstract;

namespace VotingApp
{
    public class VoitingApp
    {
        IUserService _userService;
        ICategoryService _categoryService;
        IUserCategoryService _userCategoryService;
        User _user;
        public VoitingApp(IUserService userService, ICategoryService categoryService, IUserCategoryService userCategoryService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _userCategoryService = userCategoryService;
        }
        public void Init() 
        {
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                Name = "Film"
            }) ;
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 1,
                Name = "Korku"
            });
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 1,
                Name = "Gerilim"
            });
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 1,
                Name = "Suç" 
            });
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 1,
                Name = "Drama"
            });
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 1,
                Name = "Aksiyon"
            });
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 1,
                Name = "Korku1"
            });
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 10,
                Name = "Aksiyon2"
            });
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 10,
                Name = "Aksiyon3"
            });
            _categoryService.Add(new Category()
            {
                Id = _categoryService.GenerateId(),
                SupId = 10,
                Name = "Aksiyon4"
            });


            _userService.Add(new User() 
            {
                Id = _userService.GenerateId(),
                UserName = "user1",
                Password = "1234"
            });
            _userService.Add(new User()
            {
                Id = _userService.GenerateId(),
                UserName = "user2",
                Password = "1234"
            });
            _userService.Add(new User()
            {
                Id = _userService.GenerateId(),
                UserName = "user3",
                Password = "1234"
            });
            


        }
       public List<Category> GetCategories(Category category) 
       {
            var subCategories = _categoryService.GetList(c => c.SupId == category.Id);
            if (!(subCategories.Count > 0)) return subCategories;
            else 
            {
                
                foreach(var item in subCategories) 
                { 
                    subCategories.FirstOrDefault(sc => sc.Id == item.Id ).SubCategories = GetCategories(item);
                }
                return subCategories;
            }

        } 
    
       public void Voiting() 
       {

        loginCheck:
            var result = LoginOrRegisterMenu();
            if (! result) goto loginCheck;
            Console.Clear();
            var categoryName = SelectCategoryMenu();
            var category = _categoryService.Get(c => c.NormalizedName == categoryName);
            if (category != null)
            {
                Console.Write(_user.Id);
                category.SubCategories = GetCategories(category);
                ListCategories(category);
                VoteCategory(category);


            }
            foreach (var item in _categoryService.GetList(c => c.SupId == 0)) 
            {
                item.SubCategories = GetCategories(item);
                ShowStatistic(item);
            }
            


       }
        public void ShowStatistic(Category category,int iter = 0) 
        {
            Console.WriteLine(new string(' ', iter + 1) + "=> " + category.Name+" Ort. Puan : " + _userCategoryService.GetCategoryPoint(category.Id) );
            if (category.SubCategories.Count > 0)
            {
                foreach (var item in category.SubCategories)
                {
                    ShowStatistic(item, iter + 1);
                }
            }
            else return;
        }
        public double VoteCategory(Category category,double sum = 0) 
        {
            if (!(category.SubCategories.Count> 0))
            {
                Console.Write(category.Name + " => " + "Puan: ");
                double point = Int64.Parse(Console.ReadLine());
                _userCategoryService.Add(new UserCategory()
                {
                    Id = _userCategoryService.GenerateId(),
                    CatergoryId = category.Id,
                    UserId = _user.Id,
                    Score = point,
                });
                return point;
               
            }
            foreach (var subCategory in category.SubCategories)
            {
                sum += VoteCategory(subCategory); 
            }
            Console.WriteLine(category.Name + " points " + sum / category.SubCategories.Count);
            _userCategoryService.Add(new UserCategory()
            {
                Id = _userCategoryService.GenerateId(),
                CatergoryId = category.Id,
                UserId = _user.Id,
                Score = sum / category.SubCategories.Count,
            });
            return sum / category.SubCategories.Count;
        }
        public void ListCategories(Category c,int iter=0) 
        {
            Console.WriteLine(new string(' ',iter+1) +"=> "+ c.Name);
            if(c.SubCategories.Count > 0)
            {
                foreach (var item in c.SubCategories)
                {
                    ListCategories(item,iter+1);
                }
            }
            else return;
           
        }
        public bool Register(User user)
        {
            user.Id = _userService.GenerateId();
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
                    Console.WriteLine("Giriş Başarılı\n");
                    return true;
                }
                Console.WriteLine("Şifre yanlış gardaş, \n C:\\Users\\pc\\Desktop\\Angular Proje\\angular\\VotingApp\\VotingApp\\bin\\Debug\\net5.0 altında user.json var ona bak.\nBaktıktan sonra sil!!!\n");
                return false;

            }
            Console.WriteLine("Kullanıcı bulunamadı\n");
            return false;
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

        public bool LoginOrRegisterMenu() 
        {
            Console.WriteLine("Kayıt için 'k' Giriş için 'g' ");
            Console.Write("=> ");
            var loginOrRegister = Console.ReadLine().Trim().ToLower();
            GetLoginOrRegisterInfo();
            if (loginOrRegister.Equals("k")) return Register(_user);
            else if (loginOrRegister.Equals("g")) return Login();
            else
            {
                Console.WriteLine("=> Geçersiz Giriş");
                return false;
            }
        }
        public string SelectCategoryMenu() 
        {
            Console.WriteLine("**************** OYLAMA UYGULAMASI ***************\n");
            Console.WriteLine("gardaş nerdesin sen ya " + _user.UserName.ToUpper());
            foreach (var item in _categoryService.GetList(c => c.SupId == 0))
            {
                item.SubCategories = GetCategories(item);
                ListCategories(item);

            }

            Console.Write("Değerlendirmek istediğiniz kategoriyi giriniz\n=> ");
            return Console.ReadLine().Trim().ToUpper().CharFormalization();
        }
        
    }
}
