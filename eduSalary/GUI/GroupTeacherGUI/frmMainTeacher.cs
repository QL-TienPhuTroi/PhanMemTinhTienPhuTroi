using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GroupTeacherGUI
{
    public partial class frmMainTeacher : MetroFramework.Forms.MetroForm
    {
        string pCode, pPass, pHoTen;
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        frmProfile fProfile;

        public frmMainTeacher(string Code, string Pass)
        {
            InitializeComponent();
            pCode = Code;
            pPass = Pass;
            fProfile = new frmProfile(pCode);
            pHoTen = gv_bll.getNameGiaoVien(pCode);
            setSize();
            this.Load += FrmMainTeacher_Load;
            btnFrmTeacherProfile.Click += BtnFrmTeacherProfile_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
            this.Close();
        }

        private void BtnFrmTeacherProfile_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fProfile.TopLevel = false;
            fProfile.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fProfile);
            fProfile.Show();
        }

        private void FrmMainTeacher_Load(object sender, EventArgs e)
        {
            loadGreeting();
        }

        private void loadGreeting()
        {
            string pName = getName();
            lbHello.Text = timeHi() + " " + pName;
        }

        public string timeHi()
        {
            string pHi = string.Empty;
            int pHours = DateTime.Now.Hour;;

            if (pHours >= 4 && pHours < 11)
            {
                pHi = "Chào buổi sáng!";
            }
            else if(pHours >= 11 &&  pHours < 13) 
            {
                pHi = "Chào buổi trưa!";
            }
            else if (pHours >= 13 && pHours < 18)
            {
                pHi = "Chào buổi chiều!";
            }
            else 
            {
                pHi = "Chào buổi tối!";
            }
            return pHi;
        }

        public string getName()
        {
            string[] names = pHoTen.Split(' ');
            return names[names.Length - 2] + " " + names[names.Length - 1];
        }

        public void setSize()
        {
            this.Size = new Size(1536, 816);

            pnlMenu.Size = new Size(370, 816);
            pnlMenu.Location = new Point(-46, 5);

            line1.Size = new Size(1536, 6);
            line2.Size = new Size(1200, 5);

            pnlBody.Size = new Size(1200, 655);
        }
    }
}
