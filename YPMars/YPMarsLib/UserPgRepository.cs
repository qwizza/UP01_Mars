using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class UserPgRepository : IUserRepository
    {
        public bool AuthenticateUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }
        private string HashPassword(string password) 
        {
            string result;
            return result;
        }
    }
}
