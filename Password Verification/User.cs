using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_System
{ 
    public enum UserRole
    {
        Student,
        TA,
        Professor,
    }

    public class User
    {
        public string Username { get; }
        public byte[] Salt { get; }
        public string HashedPassword { get; }
        public UserRole Role { get; }
        public string Department { get; }

        public User(string username, byte[] salt, string hashedPassword, UserRole role, string department)
        {
            Username = username;
            Salt = salt;
            HashedPassword = hashedPassword;
            Role = role;
            Department = department;
        }
    }
}
