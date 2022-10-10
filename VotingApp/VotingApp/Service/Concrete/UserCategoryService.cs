using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingApp.Service.Abstract;

namespace VotingApp.Service.Concrete
{
    public class UserCategoryService : GenericRepository <UserCategory>,IUserCategoryService
    {
        public bool Add(UserCategory userCategory) 
        {
            if(GetUserVotedCategory(userCategory.UserId,userCategory.CatergoryId) != null)
            {
                Console.WriteLine("Kategori zaten Oylanmış");
                return false;
            }
            if(!(userCategory.Score > 0 && userCategory.Score <= 10)) 
            {
                Console.WriteLine("Kategori Puanı geçersiz 1 ile 10 arası olmalıdır");
                return false;
            }
            return base.Add(userCategory);
        }
        public UserCategory GetUserVotedCategory(int userId,int categoryId) 
        {
          return base.Get(uc => (uc.CatergoryId == categoryId && uc.UserId == userId));
        }
        public double GetCategoryPoint(int categoryId) 
        {
            var result = base.GetList(uc => uc.CatergoryId == categoryId); 
            if(!(result.Count >0)) return 0;
            double sum = 0;
            int count = result.Select(uc =>
            {
                sum += uc.Score; 
                return uc;
            } ).ToList().Count();
            return sum/count;
        }
    }
}
