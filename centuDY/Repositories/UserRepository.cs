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
    }
}