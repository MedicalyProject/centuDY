﻿using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Repositories
{
    public static class UserRepository
    {
        private static centuDYDBEntities db = CentuDYDB.getInstance();

        public static List<User> getUsersMember()
        {
            return (from x in db.Users where x.RoleId == 2 select x).ToList();
        }

        public static User getUserByEmailAndPassword(string email, string password)
        {
            return (from x in db.Users
                    where x.Username.Equals(email) && x.Password.Equals(password)
                    select x).FirstOrDefault();
        }

        public static User getUserByUsername(string username)
        {
            return (from x in db.Users
                    where x.Username.Equals(username)
                    select x).FirstOrDefault();
        }

        public static Role getRole(string userRoleName)
        {
            return (from x in db.Roles
                    where x.RoleName.Equals(userRoleName)
                    select x).FirstOrDefault();
        }

        public static User getUserById(int id)
        {
            return (from x in db.Users where x.UserId == id select x).FirstOrDefault();
        }

        public static bool deleteUser(int id)
        {
            User user = getUserById(id);

            if (user == null)
            {
                return false;
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return true;
        }

        public static bool addNewUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
            catch (Exception er)
            {

                throw er;
            }
        }
    }
}