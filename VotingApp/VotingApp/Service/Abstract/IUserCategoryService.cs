using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.Service.Abstract
{
    public interface IUserCategoryService : IService<UserCategory>
    {
        UserCategory GetUserVotedCategory(int userId, int categoryId);
        bool Add(UserCategory userCategory);
        double GetCategoryPoint(int categoryId);
    }
}
