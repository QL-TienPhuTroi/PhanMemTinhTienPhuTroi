﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChucVuDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public ChucVuDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHỨC VỤ
        public List<ChucVuDTO> getDataChucVu()
        {
            var chucvus = from cv in qlgv.CHUCVUs select new ChucVuDTO()
            {
                macv = cv.MACV,
                tencv = cv.TENCV
            };

            List<ChucVuDTO> lst_cv = chucvus.ToList();

            return lst_cv;
        }
    }
}
