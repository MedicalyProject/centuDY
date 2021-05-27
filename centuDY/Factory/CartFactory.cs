using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Factory
{
    public static class CartFactory
    {
        public static Cart createCart(int userId, int medicineId, int quantity)
        {
            Cart cart = new Cart();
            cart.UserId = userId;
            cart.MedicineId = medicineId;
            cart.Quantity = quantity;

            return cart;
        }
    }
}