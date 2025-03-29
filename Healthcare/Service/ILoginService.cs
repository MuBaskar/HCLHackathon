using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILoginService
    {
        Task<string> LoginAsync(string email, string password);

    }
}
