using APIAuthen.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthen.Services
{
    public class UserRepository : IUserRepository
    {
        public bool ValidateCredentials(string user, string password)
        {
            return true;
        }
    }
}
