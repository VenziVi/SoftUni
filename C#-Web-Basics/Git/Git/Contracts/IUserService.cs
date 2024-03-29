﻿using Git.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Contracts
{
    public interface IUserService
    {
        bool IsRegistred(RegisterViewModel model);
        string IsLogged(LoginViewModel model);
    }
}
