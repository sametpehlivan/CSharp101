using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Entities
{
    public class UserCategory : BaseEntitiy
    {

        public int CatergoryId { get; set; }
        public int UserId { get; set; }
        public double Score { get; set; }
    }
}
