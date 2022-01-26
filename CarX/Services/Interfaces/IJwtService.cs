using CarX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(List<string> roles, AppUser user);
    }
}
