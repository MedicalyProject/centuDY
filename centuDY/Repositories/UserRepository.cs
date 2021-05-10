using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Repositories
{
    public static class UserRepository
    {
        private static CentuDYDBEntities db = CentuDYDB.getInstance();

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