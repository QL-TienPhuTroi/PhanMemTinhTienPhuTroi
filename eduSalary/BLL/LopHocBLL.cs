﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class LopHocBLL
    {
        LopHocDAL lp_dal = new LopHocDAL();

        public LopHocBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU LỚP HỌC
        public List<LopHocDTO> getDataLopHoc()
        {
            return lp_dal.getDataLopHoc();
        }

        //------------------ LẤY DỮ LIỆU LỚP HỌC THEO KHỐI
        public List<LopHocDTO> getDataLopHocTheoKhoi(string pValue)
        {
            return lp_dal.getDataLopHocTheoKhoi(pValue);
        }

        //------------------ KIỂM TRA LỚP KHUYÊT TẬT
        public bool isDisabilities()
        {
            return lp_dal.isDisabilities();
        }
    }
}
