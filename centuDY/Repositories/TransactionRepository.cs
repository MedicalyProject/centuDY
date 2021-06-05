using centuDY.Factory;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Repositories
{
    public static class TransactionRepository
    {
        private static CentuDYDBEntities db = CentuDYDB.getInstance();

        public static List<DetailTransaction> getTransactionsByUserId(int userId)
        {
            return (from x in db.DetailTransactions
                    where x.HeaderTransaction.UserId == userId select x).ToList();
        }

        public static List<HeaderTransaction> getHeaderTransactionsByUserId(int userId)
        {
            return (from x in db.HeaderTransactions
                    where x.UserId == userId
                    select x).ToList();
        }

        //0 references? considering to remove (?)
        public static List<HeaderTransaction> getHeaderTransactionsById(int id)
        {
            return (from x in db.HeaderTransactions
                    where x.TransactionId == id
                    select x).ToList();
        }

        public static DetailTransaction getDetailTransaction(int transactionId, int medicineId)
        {
            return (from x in db.DetailTransactions
                    where x.TransactionId == transactionId && x.MedicineId == medicineId
                    select x).FirstOrDefault();
        }

        public static List<DetailTransaction> getDetailTransactionByMedicineId(int medicineId)
        {
            return (from x in db.DetailTransactions
                    where x.MedicineId == medicineId
                    select x).ToList();
        }

        public static HeaderTransaction getHeaderTransaction(int id)
        {
            return (from x in db.HeaderTransactions
                    where x.TransactionId == id
                    select x).FirstOrDefault();
        }

        public static List<DetailTransaction> getAllTransactions()
        {
            return (from x in db.DetailTransactions select x).ToList();
        }

        public static List<HeaderTransaction> getAllTransactionsByHeader()
        {
            return (from x in db.HeaderTransactions select x).ToList();
        }

        public static bool addNewTransaction(HeaderTransaction transaction)
        {
            try
            {              
                db.HeaderTransactions.Add(transaction);
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public static bool deleteDetailTransaction(int transactionId, int medicineId)
        {
            try
            {

                DetailTransaction transaction = getDetailTransaction(transactionId, medicineId);

                db.DetailTransactions.Remove(transaction);
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public static bool deleteHeaderTransaction(int id)
        {
            try
            {

                HeaderTransaction transaction = getHeaderTransaction(id);

                db.HeaderTransactions.Remove(transaction);
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