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

        public static List<User> getAllMember()
        {
            return UserRepository.getUsersMember();
        }

        public static User getUser(int id)
        {
            if (UserRepository.getUserById(id) != null)
            {
                return UserRepository.getUserById(id);
            }

            return null;
        }

        public static bool checkOldPassword(int id, string password)
        {
            User user = UserRepository.getUserById(id);

            if (user.Password.Equals(password))
            {
                return true;
            }

            return false;
        }


        public static User getUserByUsernameAndPassword(string username, string password)
        {
            if (username != null && password != null)
            {
                if (UserRepository.getUserByUsernameAndPassword(username, password) != null)
                {
                    return UserRepository.getUserByUsernameAndPassword(username, password);
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

        public static bool updateProfile(int id, string name, string gender, string phoneNumber, string address)
        {
            if (UserRepository.updateProfile(id, name, gender, phoneNumber, address))
            {
                return true;
            }

            return false;
        }

        public static bool changePassword(int id, string password)
        {
            if (UserRepository.updatePassword(id, password))
            {
                return true;
            }

            return false;
        }

        public static bool deleteUser(int id)
        {
       
            List<HeaderTransaction> transactions = TransactionRepository.getHeaderTransactionsByUserId(id);
            if (!TransactionsHandler.deleteTransaction(transactions)) { return false; }

            List<Cart> carts = CartRepository.getCartsByUserId(id);

            if (!CartHandler.deleteCartList(carts)) { return false; }

            if (UserRepository.deleteUser(id))
            {
                return true;
            }
            return false;
        }




    }
}