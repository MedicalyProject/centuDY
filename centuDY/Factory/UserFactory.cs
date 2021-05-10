
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Factory
{
    public static class UserFactory
    {
        public static User createUser(int roleId, string username, string password, string name, string gender, string phoneNumber, string address)
        {
            User user = new User();
            user.RoleId = roleId; 
            user.Name = name;
            user.Username = username;
            user.Password = password;
            user.Gender = gender;
            user.PhoneNumber = phoneNumber;
            user.Address = address;

            return user;
        }
    }
}