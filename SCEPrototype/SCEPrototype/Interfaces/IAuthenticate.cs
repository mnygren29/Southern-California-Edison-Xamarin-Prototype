﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCEPrototype.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync();

        Task<bool> LogoutAsync();
    }
}
