using centuDY.Handlers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Controllers
{
    public static class UserController
    {
        public static List<User> getMembers()
        {
            return UserHandler.getAllMember();
        }

        public static string deleteMemberById(string id)
        {
            if (!UserHandler.deleteUser(int.Parse(id)))
            {
                return "[!] DeleteError: User Not Found!";
            }

            return "[!] Delete Success";
        }
    }
}