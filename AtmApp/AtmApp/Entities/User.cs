using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AtmApp.Entities
{
    public class User : BaseEntitiy
    {
        private string _userName;
        public string UserName { get => _userName; set { 
            _userName = value.Trim();
            } 
        }
        public double Amount {get; set;}
        public string Password { get; set; }
        
    }
}
