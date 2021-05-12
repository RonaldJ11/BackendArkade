using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARKADE_API0._001.Authenticator
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string nickName, string password);
    }
}
