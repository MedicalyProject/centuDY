using centuDY.Handlers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Controllers
{
    public class MedicineController
    {
        private static int medicine_stock = 0;
        private static int medicine_price = 0;

        public static string addMedicine(string name, string description, string stock, string price)
        {

            string response = validateMedicine(name, description, stock, price);

            if (response.Equals(""))
            {
                MedicineHandler.addMedicine(name, description, medicine_stock, medicine_price);
                response = "Sucess add new medicine!";
            }

            return response;
        }

        public static List<Medicine> getAllMedicine()
        {
            return MedicineHandler.getMedicines();
        }

        public static List<Medicine> getMedicineName(string name)
        {
            return MedicineHandler.getFilteredMedicines(name);
        }

        public static Medicine getMedicineById(string id)
        {
            return MedicineHandler.getMedicine(int.Parse(id));
        }

        public static string updateMedicine(string id, string name, string description, string stock, string price)
        {

            string response = validateMedicine(name, description, stock, price);

            if (response.Equals(""))
            {
                MedicineHandler.updateMedicine(int.Parse(id), name, description, medicine_stock, medicine_price);
                response = "";
            }

            return response;
        }

        public static string deleteMedicineById(string id)
        {
            if (!MedicineHandler.deleteMedicine(int.Parse(id)))
            {
                return "[!] DeleteError: Toy Not Found!";
            }

            return "[!] Delete Success";
        }


        private static string validateMedicine(string name, string description, string stock, string price)
        {
            if (name.Length <= 0)
            {
                return "[!] Medicine name cannot be empty!";
            }

            if (description.Length <= 0)
            {
                return "[!] Medicion description cannot be empty!";
            }

            if (description.Length < 10)
            {
                return "[!] Medicine description must be at least 10 characters long!";
            }

            if (stock.Length <= 0)
            {
                return "[!] Medicine stock cannot be empty!";
            }

            try
            {
                medicine_stock = int.Parse(stock);
            }
            catch (Exception args)
            {
                medicine_stock = 0;
            }

            if (medicine_stock == 0)
            {
                return "[!] Medicine stock must be numeric";
            }

            if (medicine_stock < 0)
            {
                return "[!] Medicine stock must more than 0";
            }


            if (price.Length <= 0)
            {
                return "[!] Medicine price cannot be empty!";
            }

            try
            {
                medicine_price = int.Parse(price);
            }
            catch (Exception args)
            {
                medicine_price = 0;
            }

            if (medicine_price == 0)
            {
                return "[!] Medicine price must be numeric";
            }

            if (medicine_price < 0)
            {
                return "[!] Medicine price must more than 0";
            }

            return "";
        }
    }
}