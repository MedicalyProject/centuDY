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

        public static List<HeaderTransaction> getAllTransactionsByHeader()
        {
            return TransactionRepository.getAllTransactionsByHeader();
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

        public static bool deleteDetailTransaction(List<DetailTransaction> detailTransactions)
        {
            foreach (DetailTransaction detailTransaction in detailTransactions)
            {
                bool check = TransactionRepository.deleteDetailTransaction(detailTransaction.TransactionId, detailTransaction.MedicineId);

                if (!check)
                {
                    return false;
                }

            }
            return true;
        }

        public static bool deleteTransaction(List<HeaderTransaction> transactions)
        {
            foreach (HeaderTransaction transaction in transactions)
            {
                int userId = 0;
                if (transaction.UserId == null)
                    userId = 0;
                else
                    userId = transaction.UserId.Value;

                List<DetailTransaction> detailTransactions = TransactionRepository.getTransactionsByUserId(userId);

                if (deleteDetailTransaction(detailTransactions))
                {
                    bool check = TransactionRepository.deleteHeaderTransaction(transaction.TransactionId);
                    if (!check) { return false; };
                }
            }
            return true;
        }

    }
}