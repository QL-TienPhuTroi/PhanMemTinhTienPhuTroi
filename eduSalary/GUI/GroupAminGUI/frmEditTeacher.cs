﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI.GroupAminGUI
{
    public partial class frmEditTeacher : Form
    {
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        GiaoVienDTO gv_dto = new GiaoVienDTO();

        BacLuongBLL bl_bll = new BacLuongBLL();
        ChucDanhBLL cd_bll = new ChucDanhBLL();
        ChuyenMonBLL cm_bll = new ChuyenMonBLL();

        string pMaGV;
        List<GiaoVienDTO> lst_gv = new List<GiaoVienDTO>();

        public frmEditTeacher(string _magv)
        {
            InitializeComponent();
            pMaGV = _magv;
            this.Load += FrmEditTeacher_Load;
            btnFinish.Click += BtnFinish_Click;
            cboMSCD.SelectedIndexChanged += CboMSCD_SelectedIndexChanged;
        }

        private void CboMSCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataBacLuong();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                gv_dto.magv = pMaGV;
                gv_dto.hoten = txtHoTen.Text;
                gv_dto.ngaysinh = DateTime.Parse(dtpNgaySinh.Value.ToString());
                if (rdoNam.Checked)
                {
                    gv_dto.gioitinh = "Nam";
                }
                else
                {
                    gv_dto.gioitinh = "Nữ";
                }
                gv_dto.diachi = txtDiaChi.Text;
                gv_dto.sodienthoai = txtSDT.Text;
                gv_dto.cccd = txtCCCD.Text;
                gv_dto.email = txtEmail.Text;
                gv_dto.ngayvaotruong = DateTime.Parse(dtpNgayVT.Value.ToString());
                gv_dto.ngayvaodang = DateTime.Parse(dtpNgayVD.Value.ToString());
                gv_dto.donvicongtac = txtDonVi.Text;
                gv_dto.dantoc = txtDanToc.Text;
                gv_dto.tongiao = txtTonGiao.Text;
                gv_dto.thamnien = int.Parse(txtThamNien.Text);
                gv_dto.masocd = cboMSCD.SelectedValue.ToString();
                gv_dto.bac = int.Parse(cboBac.SelectedValue.ToString());
                gv_dto.macm = int.Parse(cboChuyenMon.SelectedValue.ToString());

                gv_bll.editGV(gv_dto);
                MessageBox.Show("GIÁO VIÊN " + gv_dto.hoten + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmEditTeacher_Load(object sender, EventArgs e)
        {
            loadDataChucDanh();
            loadDataChuyenMon();
            loadDataBacLuong();
            loadData();
        }

        private void loadData()
        {
            lst_gv = gv_bll.getDataGiaoVienTheoMa(pMaGV);


            txtHoTen.Text = lst_gv[0].hoten;
            dtpNgaySinh.Text = lst_gv[0].ngaysinh.ToString();
            if(lst_gv[0].gioitinh == "Nam")
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNam.Checked = false;
            }
            txtDiaChi.Text = lst_gv[0].diachi;
            txtSDT.Text = lst_gv[0].sodienthoai;
            txtCCCD.Text = lst_gv[0].cccd;
            txtEmail.Text = lst_gv[0].email;
            dtpNgayVT.Text = lst_gv[0].ngayvaotruong.ToString();
            dtpNgayVD.Text = lst_gv[0].ngayvaodang.ToString();
            txtDonVi.Text = lst_gv[0].donvicongtac;
            txtDanToc.Text = lst_gv[0].dantoc;
            txtTonGiao.Text = lst_gv[0].tongiao;
            txtThamNien.Text = lst_gv[0].thamnien.ToString();
            cboMSCD.Text = lst_gv[0].masocd;
            cboBac.Text = lst_gv[0].bac.ToString();
            cboChuyenMon.Text = lst_gv[0].macm.ToString();

        }

        private void loadDataBacLuong()
        {
            string pMaCD = cboMSCD.SelectedValue.ToString();
            cboBac.DataSource = bl_bll.getDataBacLuongTheoMaCD(pMaCD);
            cboBac.DisplayMember = "BAC";
            cboBac.ValueMember = "BAC";
        }

        private void loadDataChucDanh()
        {
            cboMSCD.DataSource = cd_bll.getDataChucDanh();
            cboMSCD.DisplayMember = "MASOCD";
            cboMSCD.ValueMember = "MASOCD";
        }

        private void loadDataChuyenMon()
        {
            cboChuyenMon.DataSource = cm_bll.getDataChuyenMon();
            cboChuyenMon.DisplayMember = "TENCM";
            cboChuyenMon.ValueMember = "MACM";
        }
    }
}
