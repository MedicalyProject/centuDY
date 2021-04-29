using centuDY.Models;
using centuDY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Handlers
{
    public static class UserHandlers
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
    }
}