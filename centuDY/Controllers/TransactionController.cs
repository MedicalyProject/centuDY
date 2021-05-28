using centuDY.Handlers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace centuDY.Controllers
{
    public static class TransactionController
    {
        public static List<DetailTransaction> getTransactionByUser(int id)
        {
            return TransactionsHandler.getTransactionsByUserId(id);
        }

        public static List<DetailTransaction> getTransactions()
        {
            return TransactionsHandler.getTransactions();
        }

        public static string addTransactions(int userId, List<Cart> carts)
        {
            bool success = TransactionsHandler.addTransaction(userId, carts);
            if (!success)
            {
                return "[!] Unexpected error occured. Failed to checkout";
            }

            return "";
        }
    }
}