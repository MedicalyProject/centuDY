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
            if (MedicineRepository.deleteMedicine(id))
            {
                return true;
            }
            return false;
        }
    }
}