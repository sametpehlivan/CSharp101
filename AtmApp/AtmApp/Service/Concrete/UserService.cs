using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtmApp.Entities;
using AtmApp.Service.Abstract;

namespace AtmApp.Service.Concrete
{
    public  class UserService : GenericRepository<User>,IUserService
    {
        public bool Add(User entity) 
        {
            List<User> entities = this.GetList();
            var result = entities.FirstOrDefault(x => x.UserName == entity.UserName);
            if (result != null) return false;
            return base.Add(entity);
        }
    }
}
