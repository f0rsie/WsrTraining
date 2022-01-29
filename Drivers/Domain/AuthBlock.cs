using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Domain
{
    public class AuthBlock
    {
        public bool Auth(string login, string password)
        {
            if (login == "inspector" && password == "inspector")
                return true;

            return false;
        }
    }
}
