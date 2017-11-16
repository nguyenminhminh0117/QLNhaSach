using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLBanSach.Models;
namespace QLBanSach.Dao
{
    public class CTDatHangDao
    {
        QLBS db = null;
        public CTDatHangDao()
        {
            db = new QLBS();
        }
        public bool Insert(CT_DATHANG ctdathang)
        {
            try
            {
                db.CT_DATHANG.Add(ctdathang);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
