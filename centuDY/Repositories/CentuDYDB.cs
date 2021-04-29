using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using centuDY.Models;

namespace centuDY.Repositories
{
    public static class CentuDYDB
    {
        private static CentuDYDBEntities db = null;

        public static CentuDYDBEntities getInstance()
        {
            if (db == null)
            {
                db = new CentuDYDBEntities();
            }
            return db;
        }
    }
}