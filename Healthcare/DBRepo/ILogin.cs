using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepo
{
    public interface ILogin
    {

        Task<User> LoginAsync(string email, string password);
    }
}
