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
        public frmAddSubject()
        {
            InitializeComponent();
            this.Load += FrmAddSubject_Load;
            btnFinish.Click += BtnFinish_Click;
            this.Load += FrmAddSubject_Load1;

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
            txtMaMH.Enabled = false;
        }
        private int createCode()
        {
            Random random = new Random();
            int startingNumber = 19;
            while (true)
            {
                int randomNumber = random.Next(1, 1000000 - startingNumber);
                int pMaMH = startingNumber + randomNumber;

                if (!mh_bll.checkPK(pMaMH))
                {
                    return pMaMH;
                }
            }
        }
    }
}
