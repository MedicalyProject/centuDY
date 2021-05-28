using centuDY.Factory;
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

        public static List<Cart> getCartsByMedicineId(int id)
        {
            return CartRepository.getCartsByMedicineId(id);
        }

        //mengembalikan jumlah kuantitas medicine terpilih di cart yang belum di checkout
        public static int medicineQuantityReservedInOtherCarts(int medicineId)
        {
            List<Cart> cartWithMedicine = getCartsByMedicineId(medicineId);
            return cartWithMedicine.Sum(cart => cart.Quantity);
        }

        //cek apakah medicine sudah ada di cart milik user
        private static bool cartByUserIdAndMedicineIdExist(int userId, int medicineId)
        {
            if (CartRepository.getCartsByUserIdAndMedicineId(userId, medicineId) != null)
            {
                return true;
            }
            return false;
        }

        public static bool deleteCart(int userId, int medicineId)
        {
            if (CartRepository.deleteCart(userId, medicineId))
            {
                return true;
            }
            return false;
        }

        //delegasi untuk mengurangi stok medicine dan untuk menghapus cart yang dibuat user 
        public static bool emptyCarts(int userId, List<Cart> carts)
        {
            foreach(Cart cart in carts)
            {
                if(!MedicineRepository.reduceMedicineStock(cart.MedicineId, cart.Quantity)) return false;
                if(!CartRepository.deleteCart(userId, cart.MedicineId)) return false;
            }
            return true;
        }

        //handler untuk menambah medicine ke cart
        public static bool addToCart(int userId, int medicineId, int qty)
        {
            if (cartByUserIdAndMedicineIdExist(userId, medicineId))
            {
                return addQuantityToExistingCart(userId,medicineId,qty);
            }
 
            Cart cart = CartFactory.createCart(userId, medicineId, qty);
            if (CartRepository.addNewCart(cart))
            {
                return true;
            }
            return false;
        }

        //dipanggil ketika medicine sudah ada di cart
        private static bool addQuantityToExistingCart(int userId, int medicineId, int qty)
        {
            if (CartRepository.addQuantityToCart(userId, medicineId, qty))
            {
                return true;
            }
            return false;
        }

        public static bool deleteCartList(List<Cart> carts)
        {

            foreach (Cart cart in carts)
            {
                bool check = CartRepository.deleteCart(cart.UserId, cart.MedicineId);
                if (!check) { return false; }

            }

            return true;
        }
    }
}