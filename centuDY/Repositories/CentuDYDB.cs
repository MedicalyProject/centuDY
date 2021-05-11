using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using centuDY.Models;

namespace centuDY.Repositories
{
    public static class CentuDYDB
    {
        private static centuDYDBEntities db = null;

        public static centuDYDBEntities getInstance()
        {
            if (db == null)
            {
                db = new centuDYDBEntities();
            }
            return db;
        }
    }
}