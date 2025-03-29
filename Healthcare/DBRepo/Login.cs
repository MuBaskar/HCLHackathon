using Microsoft.EntityFrameworkCore;
using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepo
{
    public class Login :ILogin
    {

        public  HealthCareDbContext  _HealthCareDbContext;
        public Login(HealthCareDbContext HealthCareDbContext)
        {
            _HealthCareDbContext = HealthCareDbContext;
        }
      public async Task<User> LoginAsync(string email, string password)
        {
            var result = await _HealthCareDbContext.User.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
            return result;
        }
    }
}
