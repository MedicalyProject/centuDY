using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Factory
{
    public static class MedicineFactory {
        public static Medicine createMedicine(string name, string description, int stock, int price)
        {
            Medicine medicine = new Medicine();
            medicine.Name = name;
            medicine.Description = description;
            medicine.Stock = stock;
            medicine.Price = price;

            return medicine;
        }
    }
}