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
        ChuyenMonBLL cm_bll = new ChuyenMonBLL();
        KhoiBLL kh_bll = new KhoiBLL();
        LopHocBLL lp_bll = new LopHocBLL();
        
        int pMaMH;
        List<MonHocDTO> lst_mh = new List<MonHocDTO>();
        public frmEditSubject(int _MaMH)
        {
            InitializeComponent();
            pMaMH = _MaMH;
            this.Load += FrmEditSubject_Load;
            btnFinish.Click += BtnFinish_Click;
            txtMaMH.Enabled = false;
            txtTietToiDa.KeyPress += TxtTietToiDa_KeyPress;
        }

        private void TxtTietToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                mh_dto.mamh = pMaMH;
                mh_dto.tenmh = txtTenMH.Text;
                mh_dto.tiettoida = int.Parse(txtTietToiDa.Text);
                mh_dto.macm = int.Parse(cboMaCM.SelectedValue.ToString());
                mh_dto.makhoi = int.Parse(cboMaKhoi.SelectedValue.ToString());
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
            loadDataChuyenMon();
            loadDataKhoi();
            loadData();
            
        }
        private void loadData()
        {
            lst_mh = mh_bll.getDataMonHocTheoMa(pMaMH);
            txtMaMH.Text = lst_mh[0].mamh.ToString();
            txtTenMH.Text = lst_mh[0].tenmh;
            txtTietToiDa.Text = lst_mh[0].tiettoida.ToString();

            int pMaKhoi = mh_bll.getKhoi(lst_mh[0].mamh);
            string pTenKhoi = kh_bll.getDataTenKhoiTheoMa(pMaKhoi);
            cboMaKhoi.Text = pTenKhoi;

            int pMaCM = mh_bll.getChuyenMon(lst_mh[0].macm);
            string pTenCM = cm_bll.getDataCHuyenMonTheoMaCM(pMaCM).ToString();
            cboMaCM.Text = pTenCM;


        }
        private void loadDataChuyenMon()
        {
            cboMaCM.DataSource = cm_bll.getDataChuyenMon();
            cboMaCM.DisplayMember = "TENCM";
            cboMaCM.ValueMember = "MACM";
        }
        private void loadDataKhoi()
        {
            cboMaKhoi.DataSource = kh_bll.getDataKhoi();
            cboMaKhoi.DisplayMember = "TENKHOI";
            cboMaKhoi.ValueMember = "MAKHOI";
        }


    }
}
