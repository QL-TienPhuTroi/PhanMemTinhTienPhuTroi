﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChuyenMonBLL
    {
        ChuyenMonDAL cm_dal = new ChuyenMonDAL();

        //------------------ LẤY DỮ LIỆU CHUYÊN MÔN
        public List<ChuyenMonDTO> getDataChuyenMon()
        {
            return cm_dal.getDataChuyenMon();
        }

        //------------------ LẤY DỮ LIỆU CHUYÊN MÔN THEO MÃ CHUYÊN MÔN
        public List<ChuyenMonDTO> getDataChuyenMonTheoMa(int pMaCM)
        {
            return cm_dal.getDataChuyenMonTheoMa(pMaCM);
        }
        //------------------ LẤY DỮ LIỆU CHUYÊN MÔN THEO MÃ
        public string getDataCHuyenMonTheoMaCM(int pMaCM)
        {
            return cm_dal.getDataCHuyenMonTheoMaCM(pMaCM);
        }

    }
}
