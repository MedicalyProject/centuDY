using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace centuDY.Factory
{
    public static class TransactionFactory
    {
        public static HeaderTransaction createTransaction(int userId)
        {
            HeaderTransaction header = new HeaderTransaction();
            header.UserId = userId;
            header.TransactionDate = DateTime.Now;        

            return header;
        }
    }
}