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
        private static string gender = "";

        public static List<User> getMembers()
        {
            return UserHandler.getAllMember();
        }

        public static User getUser(int id)
        {
            if (id.ToString() != null)
            {
                return UserHandler.getUser(id);
            }

            return null;
        }

        public static string updateProfile(int id, string name, bool rb_male, bool rb_female, string phoneNumber, string address)
        {

            string response = validateProfile(name, rb_male, rb_female, phoneNumber, address);

            if (response.Equals(""))
            {
                UserHandler.updateProfile(id, name, gender, phoneNumber, address);
                response = "";
            }

            return response;
        }

        public static string updatePassword(int id, string oldPassword, string newPassword, string confirmPassword)
        {

            string response = validatePassword(id, oldPassword, newPassword, confirmPassword);

            if (response.Equals(""))
            {
                UserHandler.changePassword(id, newPassword);
                response = "";
            }

            return response;
        }

        public static string deleteMemberById(string id)
        {
            if (!UserHandler.deleteUser(int.Parse(id)))
            {
                return "[!] DeleteError: User Not Found!";
            }

            return "[!] Delete Success";
        }

        public static string validateProfile(string name, bool rb_male, bool rb_female, string phoneNumber, string address)
        {

            if (name.Length <= 0)
            {
                return "[!] Name cannot be empty!";
            }

            if (!rb_male)
            {
                if (!rb_female)
                {
                    return "[!] Gender must be chosen!";
                }

                gender = "Female";
            }

            if (!rb_female)
            {
                if (!rb_male)
                {
                    return "[!] Gender must be chosen!";
                }

                gender = "Male";
            }

            if (phoneNumber.Length <= 0)
            {
                return "[!] Phone number cannot be empty!";
            }

            int phoneNumberInt;

            if (!int.TryParse(phoneNumber, out phoneNumberInt))
            {
                return "[!] Phone number must be numeric!";
            }

            if (address.Length <= 0)
            {
                return "[!] Address cannot be empty!";
            }

            if (address.Length <= 0)
            {
                return "[!] Address cannot be empty!";
            }

            if (!address.Contains("Street"))
            {
                return "[!] Address must contain the word 'Street'";
            }

            return "";
        }

        public static string validatePassword(int id, string oldPassword, string newPassword, string confirmPassword)
        {
            if (oldPassword.Length <= 0)
            {
                return "[!] Old Password cannot be empty!";
            }


            if (!UserHandler.checkOldPassword(id, oldPassword))
            {
                return "[!] Password must match with the password in database!";
            }

            if (newPassword.Length <= 0)
            {
                return "[!] New Password cannot be empty!";
            }

            if (newPassword.Length <= 8)
            {
                return "[!] New Password cannot be less than 8 characters!";
            }

            if (confirmPassword.Length <= 0)
            {
                return "[!] Confirm Password cannot be empty!";
            }

            if (!confirmPassword.Equals(newPassword))
            {
                return "[!] Must be the same as the inputted password!";
            }

            return "";
        }
    }
}