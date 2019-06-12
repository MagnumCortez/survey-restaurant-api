using Restaurant.Api.UoW.Infra;
using Restaurant.BLL.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Api.UoW
{
    public class LoginUoW : ILoginUoW
    {
        public ILoginBLL loginBLL { get; }

        public LoginUoW(ILoginBLL loginBLL)
        {
            this.loginBLL = loginBLL;
        }
    }
}
