using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GroupAminGUI
{
    public partial class frmEditSubject : Form
    {
        MonHocBLL mh_bll = new MonHocBLL();
        MonHocDTO mh_dto = new MonHocDTO();
        int pMaMH;
        List<MonHocDTO> lst_mh = new List<MonHocDTO>();
        public frmEditSubject(int _MaMH)
        {
            InitializeComponent();
            pMaMH = _MaMH;
            this.Load += FrmEditSubject_Load;
            btnFinish.Click += BtnFinish_Click;
            txtMaMH.Enabled = false;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                mh_dto.mamh = pMaMH;
                mh_dto.tenmh = txtTenMH.Text;
                mh_bll.editMH(mh_dto);
                MessageBox.Show("MÔN HỌC " + mh_dto.tenmh.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmEditSubject_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            lst_mh = mh_bll.getDataMonHocTheoMa(pMaMH);
            txtMaMH.Text = lst_mh[0].mamh.ToString();
            txtTenMH.Text = lst_mh[0].tenmh;
        }

    }
}
