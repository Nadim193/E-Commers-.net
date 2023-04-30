using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{


    internal class SalesReportRepo : Repo, IRepo<SalesReport, int, bool>
    {
        public bool Create(SalesReport obj)
        {
            db.SalesReports.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.SalesReports.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<SalesReport> Read()
        {
            return db.SalesReports.ToList();
        }

        public SalesReport Read(int id)
        {
            return db.SalesReports.Find(id);
        }

        public bool Update(SalesReport Obj)
        {
            var ex = Read(Obj.Id);
            db.Entry(ex).CurrentValues.SetValues(Obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}

