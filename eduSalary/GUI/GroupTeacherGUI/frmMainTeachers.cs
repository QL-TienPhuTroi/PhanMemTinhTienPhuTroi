using BLL;
using GUI.GroupAminGUI;
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
    public partial class frmMainTeachers : Form
    {
        string pMaGV, pMatKhau, pHoTen;
        GiaoVienBLL gv_bll = new GiaoVienBLL();

        frmHomeTeacher fHomeTeacher;
        frmProfile fProfile;
        frmTeachingSchedule fTeachingSchedule;

        public frmMainTeachers(string _magv, string _matkhau)
        {
            InitializeComponent();
            pMaGV = _magv;
            pMatKhau = _matkhau;
            pHoTen = gv_bll.getNameGiaoVien(pMaGV);            
            this.Load += FrmMainTeachers_Load;
            btnLogout.Click += BtnLogout_Click;
            btnTeacherDetail.Click += BtnTeacherDetail_Click;
            btnTeaching.Click += BtnTeaching_Click;
            btnHome.Click += BtnHome_Click;
            btnExit.Click += BtnExit_Click;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = true;
            pnlTeacherDetail.Visible = false;
            pnlTeaching.Visible = false;

            lbFrmName.Text = "TRANG CHỦ";
            fHomeTeacher = new frmHomeTeacher(pMaGV, lbNamHoc.Text);
            pnlBody.Controls.Clear();
            fHomeTeacher.TopLevel = false;
            fHomeTeacher.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fHomeTeacher);
            fHomeTeacher.Show();
        }

        private void BtnTeaching_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = false;
            pnlTeacherDetail.Visible = false;
            pnlTeaching.Visible = true;

            lbFrmName.Text = "LỊCH DẠY";
            fTeachingSchedule = new frmTeachingSchedule(pMaGV, lbNamHoc.Text);
            pnlBody.Controls.Clear();
            fTeachingSchedule.TopLevel = false;
            fTeachingSchedule.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fTeachingSchedule);
            fTeachingSchedule.Show();
        }

        private void BtnTeacherDetail_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = false;
            pnlTeacherDetail.Visible = true;
            pnlTeaching.Visible = false;

            lbFrmName.Text = "THÔNG TIN CÁ NHÂN GIÁO VIÊN";
            fProfile = new frmProfile(pMaGV);
            pnlBody.Controls.Clear();
            fProfile.TopLevel = false;
            fProfile.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fProfile);
            fProfile.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
            this.Close();
        }

        private void FrmMainTeachers_Load(object sender, EventArgs e)
        {
            setSizeFrom();
            loadGreeting();

            lbFrmName.Text = "TRANG CHỦ";
            fHomeTeacher = new frmHomeTeacher(pMaGV, lbNamHoc.Text);
            pnlBody.Controls.Clear();
            fHomeTeacher.TopLevel = false;
            fHomeTeacher.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fHomeTeacher);
            fHomeTeacher.Show();
        }

        private void loadGreeting()
        {
            string pName = getName();
            lbHello.Text = timeHi();
            lbTenGV.Text = pName.ToUpper();
            lbNamHoc.Text = getNamHoc();
        }

        public string timeHi()
        {
            string pHi = string.Empty;
            int pHours = DateTime.Now.Hour; ;

            if (pHours >= 4 && pHours < 11)
            {
                pHi = "Chào buổi sáng!";
            }
            else if (pHours >= 11 && pHours < 13)
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
            if (names.Length == 1)
            {
                return pHoTen;
            }
            return names[names.Length - 2] + " " + names[names.Length - 1];
        }

        private string getNamHoc()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int y1, y2;
            string schoolYear = string.Empty;

            if (month >= 1 && month < 9)
            {
                schoolYear = (year - 1) + "-" + year;
            }
            else
            {
                schoolYear = year + "-" + (year + 1);
            }
            return schoolYear;
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
        }
    }
}
