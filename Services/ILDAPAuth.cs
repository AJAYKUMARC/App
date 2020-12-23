using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public interface ILDAPAuth
    {
        public object ValidateUser(string username, string password);
    }
}
