﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.Service.Abstract
{
    public interface IUserService : IService<User>
    {
        bool Add(User entity);
    }
}
