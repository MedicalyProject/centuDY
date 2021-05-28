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
        private static centuDYDBEntities db = CentuDYDB.getInstance();

        public static List<DetailTransaction> getTransactionsByUserId(int userId)
        {
            return (from x in db.DetailTransactions
                    where x.HeaderTransaction.UserId == userId select x).ToList();
        }

        public static List<DetailTransaction> getAllTransactions()
        {
            return (from x in db.DetailTransactions select x).ToList();
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

    }
}