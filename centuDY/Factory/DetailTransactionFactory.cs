using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Factory
{
    public static class DetailTransactionFactory
    {
        public static DetailTransaction createDetailTransaction(int transactionId, int medicineId, int qty)
        {
            DetailTransaction detail = new DetailTransaction();
            detail.TransactionId = transactionId;
            detail.MedicineId = medicineId;
            detail.Quantity = qty;            

            return detail;
        }
    }
}