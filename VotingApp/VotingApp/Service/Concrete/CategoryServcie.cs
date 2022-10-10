using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingApp.Service.Abstract;

namespace VotingApp.Service.Concrete
{
    public class CategoryServcie : GenericRepository<Category>,ICategoryService
    {
        public bool Add(Category entity)
        {
            List<Category> entities = base.GetList();
            var result = entities.FirstOrDefault(x => x.NormalizedName == entity.NormalizedName);
            if (result != null) return false;
            return base.Add(entity);
        }
    }
}
