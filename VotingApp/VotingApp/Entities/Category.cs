using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VotingApp.Extensions;

namespace VotingApp.Entities
{
    public class Category: BaseEntitiy
    {
       
        [JsonIgnore]
        private string _name;
   
        public int SupId { get; set; }
        public string Name { get => _name; 
            set 
            {
                _name = value.CharFormalization();
                this.NormalizedName = _name.ToUpper().CharFormalization();
                
            } 
        }
        public string NormalizedName { get; set; }
        [JsonIgnore]
        public List<UserCategory> UserCategories { get; set; }
        [JsonIgnore]
        public List<Category> SubCategories { get; set; }
    }
}
