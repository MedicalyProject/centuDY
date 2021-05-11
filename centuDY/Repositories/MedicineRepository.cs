using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Repositories
{
    public static class MedicineRepository
    {
        private static centuDYDBEntities db = CentuDYDB.getInstance();

        public static List<Medicine> getMedicines()
        {
            return (from x in db.Medicines select x).ToList();
        }

        public static List<Medicine> getMedicinesByName(string name)
        {
            return (from x in db.Medicines where x.Name.Contains(name)
                    select x).ToList();
        }

        public static bool addNewMedicine(Medicine medicine)
        {
            try
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {

                throw er;
            }
        }

        public static Medicine getMedicineById(int id)
        {
            return (from x in db.Medicines
                    where x.MedicineId == id select x).FirstOrDefault();
        }

        public static bool updateMedicine(int id, string name, string description, int stock, int price)
        {
            try
            {
                Medicine medicine = getMedicineById(id);

                medicine.Name = name;
                medicine.Description = description;
                medicine.Stock = stock;
                medicine.Price = price;

                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {

                throw er;
            }
        }

        public static bool deleteMedicine(int id)
        {
            Medicine toy = getMedicineById(id);

            if (toy == null)
            {
                return false;
            }

            db.Medicines.Remove(toy);
            db.SaveChanges();

            return true;
        }
    }
}