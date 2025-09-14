using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Modules;

namespace api.interfaces
{
    public interface ITokenService
    {
        string CreateToken(Appuser appuser);
    }
}