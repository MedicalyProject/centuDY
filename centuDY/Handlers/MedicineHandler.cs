using centuDY.Factory;
using centuDY.Models;
using centuDY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Handlers
{
    public class MedicineHandler
    {
        public static List<Medicine> getMedicines()
        {
            return MedicineRepository.getMedicines();
        }

        public static List<Medicine> getRandomMedicines()
        {
            List<Medicine> medicines = MedicineRepository.getMedicines();

            Random random = new Random();
            int count = medicines.Count;

            while (count > 5)
            {
                int index = random.Next(count);
                medicines.RemoveAt(index);
                count = medicines.Count;
            }

            return medicines;
        }

        public static List<Medicine> getFilteredMedicines(string name)
        {
            return MedicineRepository.getMedicinesByName(name);
        }

        public static bool addMedicine(string name, string description, int stock, int price)
        {
            Medicine medicine = MedicineFactory.createMedicine(name, description, stock, price);

            if (MedicineRepository.addNewMedicine(medicine))
            {
                return true;
            }

            return false;
        }

        public static Medicine getMedicine(int id)
        {
            return MedicineRepository.getMedicineById(id);
        }

        public static bool updateMedicine(int id, string name, string description, int stock, int price)
        {
            if (MedicineRepository.updateMedicine(id, name, description, stock, price))
            {
                return true;
            }

            return false;
        }

        public static bool deleteMedicine(int id)
        {

            List<Cart> carts = CartRepository.getCartsByMedicineId(id);
            if (!CartHandler.deleteCartList(carts)) { return false; }

            List<DetailTransaction> detailTransactions = TransactionRepository.getDetailTransactionByMedicineId(id);
            if (!TransactionsHandler.deleteDetailTransaction(detailTransactions)) { return false; }

            if (MedicineRepository.deleteMedicine(id))
            {
                return true;
            }

            return false;
        }
    }
}