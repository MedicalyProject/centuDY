using centuDY.Handlers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Controllers
{
    public class CartController
    {
        public static List<Cart> getCartByUser(int id)
        {
            return CartHandler.getCartsByUserId(id);
        }

        public static string deleteCart(int userId, string medicineId)
        {
            if (!CartHandler.deleteCart( userId, int.Parse(medicineId)))
            {
                return "[!] DeleteError: Cart Not Found!";
            }

            return "[!] Delete Success";
        }
    }
}