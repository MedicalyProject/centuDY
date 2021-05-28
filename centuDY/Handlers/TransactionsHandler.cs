using centuDY.Factory;
using centuDY.Models;
using centuDY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Handlers
{
    public static class TransactionsHandler
    {
        public static List<DetailTransaction> getTransactions()
        {
            return TransactionRepository.getAllTransactions();
        }

        public static List<DetailTransaction> getTransactionsByUserId(int userId)
        {
            return TransactionRepository.getTransactionsByUserId(userId);
        }

        public static bool addTransaction(int userId, List<Cart> userCarts)
        {
            HeaderTransaction header = TransactionFactory.createTransaction(userId);
            foreach (Cart cartItems in userCarts)
            {
                DetailTransaction detail =
                    DetailTransactionFactory.createDetailTransaction(header.TransactionId, cartItems.MedicineId, cartItems.Quantity);
                header.DetailTransactions.Add(detail);
            }

            if (TransactionRepository.addNewTransaction(header))
            {
                return true;
            }

            return false;
        }
    }
}