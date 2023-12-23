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
    public partial class frmAddSubject : Form
    {
        MonHocBLL mh_bll = new MonHocBLL();
        MonHocDTO mh_dto = new MonHocDTO();
        ChuyenMonBLL cm_bll = new ChuyenMonBLL();
        KhoiBLL kh_bll = new KhoiBLL();
        public frmAddSubject()
        {
            InitializeComponent();
            this.Load += FrmAddSubject_Load;
            btnFinish.Click += BtnFinish_Click;
            this.Load += FrmAddSubject_Load1;
            txtTietToiDa.KeyPress += TxtTietToiDa_KeyPress;

        }

        private void TxtTietToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void FrmAddSubject_Load1(object sender, EventArgs e)
        {
            txtMaMH.Text = createCode().ToString();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            int pMaMH = createCode();
            try
            {
                mh_dto.mamh = pMaMH;
                mh_dto.tenmh = txtTenMH.Text;
                mh_dto.tiettoida = int.Parse(txtTietToiDa.Text);
                mh_dto.macm = int.Parse(cboMaCM.SelectedValue.ToString());
                mh_dto.makhoi = int.Parse(cboMaKhoi.SelectedValue.ToString());

                mh_bll.addMH(mh_dto);
                MessageBox.Show("MÔN HỌC " + mh_dto.tenmh.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmAddSubject_Load(object sender, EventArgs e)
        {
            loadDataChuyenMon();
            loadDataKhoi();
            txtMaMH.Enabled = false;
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
        private int createCode()
        {
            int pCode;
            int i = 1;

            while (true)
            {
                pCode = i;

                if (!mh_bll.checkPK(pCode))
                {
                    return pCode;
                }

                i++;
            }
        }
    }
}
