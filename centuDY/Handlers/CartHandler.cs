using centuDY.Models;
using centuDY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Handlers
{
    public static class CartHandler
    {
        public static List<Cart> getCartsByUserId(int id)
        {
            return CartRepository.getCartsByUserId(id);
        }

        public static bool deleteCart(int userId, int medicineId)
        {
            if (CartRepository.deleteCart(userId, medicineId))
            {
                return true;
            }
            return false;
        }
    }
}