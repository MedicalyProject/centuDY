using centuDY.Factory;
using centuDY.Models;
using centuDY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Handlers
{
    public static class UserHandler
    {
        public static User getUserByEmailAndPassword(string email, string password)
        {
            if (email != null && password != null)
            {
                if (UserRepository.getUserByEmailAndPassword(email, password) != null)
                {
                    return UserRepository.getUserByEmailAndPassword(email, password);
                }
            }

            return null;
        }

        public static User getUserByUsername(string username)
        {
            if (username != null)
            {
                if (UserRepository.getUserByUsername(username) != null)
                {
                    return UserRepository.getUserByUsername(username);
                }
            }

            return null;
        }

        public static bool addNewUserMember(string username, string password, string name, string gender, string phoneNumber, string address)
        {
            Role role = UserRepository.getRole("Member");
            User user = UserFactory.createUser(role.RoleId, username, password, name, gender, phoneNumber, address);
            if (UserRepository.addNewUser(user))
            {
                return true;
            }

            return false;
        }
    }
}