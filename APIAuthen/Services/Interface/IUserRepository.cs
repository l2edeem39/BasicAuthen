using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthen.Services.Interface
{
    public interface IUserRepository
    {
        public bool ValidateCredentials(string user, string password);
    }
}
