using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLBanSach.Models;

namespace QLBanSach.Dao
{
    public class DatHangDao
    {
        QLBS db = null;
        public DatHangDao()
        {
            db = new QLBS();
        }
        public string Insert(DATHANG dathang)
        {
            db.DATHANGs.Add(dathang);
            db.SaveChanges();
            return dathang.madathang;
        }
    }
}
