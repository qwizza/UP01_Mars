using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class User
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public UserRole Role { get; set; }
        public enum UserRole 
        {
            SuperUser,
            Manage_Sale,
            Warehouser
        }
    }
}
