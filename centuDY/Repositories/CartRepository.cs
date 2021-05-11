using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Repositories
{
    public static class CartRepository
    {
        private static centuDYDBEntities db = CentuDYDB.getInstance();

        public static List<Cart> getCartsByUserId(int id)
        {
            return (from x in db.Carts
                    where x.UserId == id
                    select x).ToList();
        }

        public static Cart getCartsByUserIdAndMedicineId(int userId, int medicineId)
        {
            return (from x in db.Carts
                    where x.UserId == userId && x.MedicineId == medicineId
                    select x).FirstOrDefault();
        }


        public static bool deleteCart(int userId, int medicineId)
        {
            Cart cart = getCartsByUserIdAndMedicineId(userId, medicineId);

            if (cart == null)
            {
                return false;
            }

            db.Carts.Remove(cart);
            db.SaveChanges();

            return true;
        }
    }
}