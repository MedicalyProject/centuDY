using centuDY.Handlers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Controllers
{
    public static class AuthController
    {
        private static string gender = "";

        public static  User login(string username, string password)
        {
            if (username.Length <= 0)
            {
                return null;
            }
            if (password.Length <= 0)
            {
                return null;
            }

            if (UserHandler.getUserByEmailAndPassword(username, password) != null)
            {
                return UserHandler.getUserByEmailAndPassword(username, password);
            }

            return null;
        }

        public static string register(string username, string password, string confirmPassword, string name, bool rb_male, bool rb_female, string phoneNumber, string address)
        {
            string response = validateUser(username, password, confirmPassword, name, rb_male, rb_female, phoneNumber, address);
            if (response.Equals(""))
            {
                UserHandler.addNewUserMember(username, password, name, gender, phoneNumber, address);
                response = "Success Register User!";
            }

            return response;
        }

        public static string validateUser(string username, string password,  string confirmPassword,string name,bool rb_male, bool rb_female, string phoneNumber, string address)
        {
            if (username.Length <= 0)
            {
                return "[!] Username cannot be empty!";
            }

            if (username.Length <= 3)
            {
                return "[!] Username cannot be less than 3 characters!";
            }

            if (UserHandler.getUserByUsername(username) != null)
            {
                return "[!] Username must be unique!";
            }

            if (password.Length <= 0)
            {
                return "[!] Password cannot be empty!";
            }

            if (password.Length <= 8)
            {
                return "[!] Password cannot be less than 8 characters!";
            }

            if (confirmPassword.Length <= 0)
            {
                return "[!] Confirm Password cannot be empty!";
            }

            if (!confirmPassword.Equals(password))
            {
                return "[!] Must be the same as the inputted password!";
            }

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
    }
}