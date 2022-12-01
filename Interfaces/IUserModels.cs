﻿using cty.Models;
using cty.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cty.Interfaces
{
    public interface IUserModels
    {
        UserModel login(ViewWebLogin viewWebLogin);
        Task<int> ChangePasswordAdmin(string email, UserModel userModel);
        Task<List<UserModel>> GetAllUserModel();
    }
}
