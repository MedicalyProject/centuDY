using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Repositories
{
    public static class CartRepository
    {
        private static CentuDYDBEntities db = CentuDYDB.getInstance();

        public static List<Cart> getCartsByUserId(int id)
        {
            return (from x in db.Carts
                    where x.UserId == id
                    select x).ToList();
        }

        public static List<Cart> getCartsByMedicineId(int medicineId)
        {
            return (from x in db.Carts
                    where x.MedicineId == medicineId
                    select x).ToList();
        }

        public static Cart getCartsByUserIdAndMedicineId(int userId, int medicineId)
        {
            return (from x in db.Carts
                    where x.UserId == userId && x.MedicineId == medicineId
                    select x).FirstOrDefault();
        }

        public static List<Cart> getAllCarts()
        {
            return (from x in db.Carts
                    select x).ToList();
        }

        public static bool addNewCart(Cart cart)
        {
            try
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                throw er;
            }
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

        //menambah kuantitas medicine ke item cart yang sudah ada
        public static bool addQuantityToCart(int userId, int medicineId, int qty)
        {
            try
            {
                Cart cart = getCartsByUserIdAndMedicineId(userId, medicineId);

                cart.Quantity += qty;
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {

                throw er;
            }
        }
    }
}