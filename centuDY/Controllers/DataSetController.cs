using centuDY.DataSet;
using centuDY.Handlers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace centuDY.Controllers
{
    public class DataSetController
    {
        //untuk mendapatkan dataset dan binding ke data pada db
        public static CentuDY_Transaction_Dataset getDataset()
        {
            CentuDY_Transaction_Dataset dataset = new CentuDY_Transaction_Dataset();
            List<HeaderTransaction> transactions = TransactionsHandler.getAllTransactionsByHeader();

            var header = dataset.Transactions;
            var detail = dataset.Transaction_Detail;

            foreach(HeaderTransaction tran in transactions)
            {
                DataRow header_row = header.NewRow();

                header_row["Transaction ID"] = tran.TransactionId;
                header_row["User Name"] = tran.User.Username;
                header_row["Transaction Date"] = tran.TransactionDate;
                header_row["Grand Total"] = tran.DetailTransactions.Sum(x => x.Quantity * x.Medicine.Price);

                header.Rows.Add(header_row);

                foreach (DetailTransaction det in tran.DetailTransactions)
                {
                    DataRow detail_row = detail.NewRow();

                    detail_row["Transaction ID"] = det.TransactionId;
                    detail_row["Medicine Name"] = det.Medicine.Name;
                    detail_row["Price"] = det.Medicine.Price;
                    detail_row["Quantity"] = det.Quantity;
                    detail_row["Sub Total"] = det.Medicine.Price * det.Quantity;

                    detail.Rows.Add(detail_row);
                }
            }

            return dataset;
        }
    }
}