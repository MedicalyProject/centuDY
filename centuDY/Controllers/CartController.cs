using centuDY.Handlers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Controllers
{
    public static class CartController
    {
        private static int qty_input = 0;

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

        //menambah medicine ke cart user
        public static string addItemToCart(int userId, string medicineId, string qty)
        {
            string response = validateQuantity(medicineId,qty);       

            if (response.Equals(""))
            {
                bool success = CartHandler.addToCart(userId, int.Parse(medicineId), int.Parse(qty));
                if (!success)
                {
                    response = "[!] Unexpected error occured. Failed to add to cart";
                }                   
            }

            return response;
        }

        //checkout: buat transaksi untuk tiap cart item, kemudian empty cart buat user
        public static string checkoutCartsOfUser(int userId, List<Cart> carts)
        {
            if (carts == null || carts.Count < 1) return "[!] Cart Is Empty!";

            string response = TransactionController.addTransactions(userId, carts);
            if (response.Equals(""))
            {
                bool success = CartHandler.emptyCarts(userId, carts);
                if (!success)
                {
                    response = "[!] Unexpected error occured. Failed to empty cart";
                }
                else
                {
                    response = "Succesfully checked out!";
                }
            }

            return response;
        }

        private static string validateQuantity(string medicineId, string quantity)
        {
            bool isNumeric = true;
            Medicine medicine = MedicineHandler.getMedicine(int.Parse(medicineId));
            //berisi jumlah quantity medicine yang ada di cart lain untuk jenis medicine yang dipilih
            int quantityReserved = CartHandler.medicineQuantityReservedInOtherCarts(int.Parse(medicineId));

            if (quantity.Length <= 0)
            {
                return "[!] Selected quantity cannot be empty!";
            }

            try
            {
                qty_input = int.Parse(quantity);
            }
            catch (Exception args)
            {
                isNumeric = false;
                qty_input = 0;
            }

            if (!isNumeric)
            {
                return "[!] Quantity must be numeric";
            }

            if (qty_input <= 0)
            {
                return "[!] Quantity must be more than 0";
            }

            if (qty_input > medicine.Stock)
            {
                return "[!] Quantity must be less than or equals to current stock";
            }

            //cek apakah quantity di cart lain + yang dimasukkan melebihi stok
            if(qty_input + quantityReserved > medicine.Stock)
            {
                return "[!] Quantity combined with other reserved carts exceeded medicine's current stock";
            }

            return "";
        }
    }
}