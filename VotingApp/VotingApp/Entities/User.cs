using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VotingApp.Extensions;

namespace VotingApp.Entities
{
    public class User : BaseEntitiy
    {
        private string _userName;
        public string UserName { get => _userName; set { 
            _userName = value.CharFormalization();
            } 
        }
        public string Password { get; set; }
        [JsonIgnore]
        public List<UserCategory> UserCategories { get; set; }
    }
}
