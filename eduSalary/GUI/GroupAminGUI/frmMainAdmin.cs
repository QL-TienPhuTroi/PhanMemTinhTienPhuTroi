using System;
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
using TheArtOfDevHtmlRenderer.Adapters;

namespace GUI.GroupAminGUI
{
    public partial class frmMainAdmin : Form
    {
        bool expand1 = true;
        bool expand2 = true;

        string pCode, pPass, pHoTen;

        GiaoVienBLL gv_bll = new GiaoVienBLL();

        frmTeacher fTeacher = new frmTeacher();
        frmPosition fPosition = new frmPosition();
        frmCareerTitles fCareerTitles = new frmCareerTitles();
        frmSalaryGrade fSalaryGrade = new frmSalaryGrade();
        frmClassroom fClassroom = new frmClassroom();

        frmAssigningHomeroom fAssigningHomeroom = new frmAssigningHomeroom();

        public frmMainAdmin(string Code, string Pass)
        {
            InitializeComponent();

            timerNavigationMenu1 = new Timer();
            timerNavigationMenu1.Interval = 10;
            timerNavigationMenu1.Enabled = true;

            timerNavigationMenu2 = new Timer();
            timerNavigationMenu2.Interval = 10;
            timerNavigationMenu2.Enabled = true;

            timerNavigationMenu1.Tick += TimerNavigationMenu1_Tick;
            timerNavigationMenu2.Tick += TimerNavigationMenu2_Tick;

            btnManager.Click += BtnManager_Click;
            btnAssignment.Click += BtnAssignment_Click;

            btnTeacher.Click += BtnTeacher_Click;
            btnPosition.Click += BtnPosition_Click;
            btnCareerTitles.Click += BtnCareerTitles_Click;
            btnSalaryGrade.Click += BtnSalaryGrade_Click;
            btnClassroom.Click += BtnClassroom_Click;

            btnHomeroomTeacher.Click += BtnHomeroomTeacher_Click;
            btnTeachingAssignment.Click += BtnTeachingAssignment_Click;

            btnLogout.Click += BtnLogout_Click;
            btnExit.Click += BtnExit_Click;

            this.Load += FrmMainAdmin_Load;

            pCode = Code;
            pPass = Pass;
            pHoTen = gv_bll.getNameGiaoVien(pCode); 
        }

        private void FrmMainAdmin_Load(object sender, EventArgs e)
        {
            lbQuantityTeacher.Text = getQuantityTeacher().ToString();
            loadGreeting();
            setSizeFrom();
        }

        private void BtnTeacher_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ GIÁO VIÊN";
            pnlBody.Controls.Clear();
            fTeacher.TopLevel = false;
            fTeacher.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fTeacher);
            fTeacher.Show();
        }

        private void BtnPosition_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ CHỨC VỤ";
            pnlBody.Controls.Clear();
            fPosition.TopLevel = false;
            fPosition.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fPosition);
            fPosition.Show();
        }

        private void BtnCareerTitles_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "CHỨC DANH NGHỀ NGHIỆP";
            pnlBody.Controls.Clear();
            fCareerTitles.TopLevel = false;
            fCareerTitles.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fCareerTitles);
            fCareerTitles.Show();
        }

        private void BtnSalaryGrade_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ BẬC LƯƠNG";
            pnlBody.Controls.Clear();
            fSalaryGrade.TopLevel = false;
            fSalaryGrade.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fSalaryGrade);
            fSalaryGrade.Show();
        }

        private void BtnClassroom_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ LỚP HỌC";
            pnlBody.Controls.Clear();
            fClassroom.TopLevel = false;
            fClassroom.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fClassroom);
            fClassroom.Show();
        }

        private void BtnTeachingAssignment_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnHomeroomTeacher_Click(object sender, EventArgs e)
        {
            fAssigningHomeroom.ShowDialog();
        }

        private void BtnManager_Click(object sender, EventArgs e)
        {
            timerNavigationMenu1.Start();

            if (!expand1)
            {
                btnManager.FillColor = Color.FromArgb(255, 192, 255);
                btnManager.FillColor2 = Color.FromArgb(239, 65, 102);
                btnManager.ForeColor = Color.White;
                btnManager.Image = Properties.Resources.angle_down;
            }
            else
            {
                btnManager.FillColor = Color.FromArgb(255, 192, 255);
                btnManager.FillColor2 = Color.FromArgb(255, 192, 255);
                btnManager.ForeColor = Color.FromArgb(239, 65, 102);
                btnManager.Image = Properties.Resources.angle_down_pink;
            }

            btnAssignment.FillColor = Color.FromArgb(255, 192, 255);
            btnAssignment.FillColor2 = Color.FromArgb(255, 192, 255);
            btnAssignment.ForeColor = Color.FromArgb(239, 65, 102);
            btnAssignment.Image = Properties.Resources.angle_down_pink;
        }

        private void BtnAssignment_Click(object sender, EventArgs e)
        {
            timerNavigationMenu2.Start();

            if (!expand2)
            {
                btnAssignment.FillColor = Color.FromArgb(255, 192, 255);
                btnAssignment.FillColor2 = Color.FromArgb(239, 65, 102);
                btnAssignment.ForeColor = Color.White;
                btnAssignment.Image = Properties.Resources.angle_down;
            }
            else
            {
                btnAssignment.FillColor = Color.FromArgb(255, 192, 255);
                btnAssignment.FillColor2 = Color.FromArgb(255, 192, 255);
                btnAssignment.ForeColor = Color.FromArgb(239, 65, 102);
                btnAssignment.Image = Properties.Resources.angle_down_pink;
            }

            btnManager.FillColor = Color.FromArgb(255, 192, 255);
            btnManager.FillColor2 = Color.FromArgb(255, 192, 255);
            btnManager.ForeColor = Color.FromArgb(239, 65, 102);
            btnManager.Image = Properties.Resources.angle_down_pink;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TimerNavigationMenu1_Tick(object sender, EventArgs e)
        {
            if (!expand1)
            {
                dropDownMenu1.Height += 15;
                if(dropDownMenu1.Height >= dropDownMenu1.MaximumSize.Height)
                {
                    timerNavigationMenu1.Stop();
                    expand1 = true;
                }
            }
            else
            {
                dropDownMenu1.Height -= 15;
                if (dropDownMenu1.Height <= dropDownMenu1.MinimumSize.Height)
                {
                    timerNavigationMenu1.Stop();
                    expand1 = false;
                }
            }
        }

        private void TimerNavigationMenu2_Tick(object sender, EventArgs e)
        {
            if (!expand2)
            {
                dropDownMenu2.Height += 15;
                if (dropDownMenu2.Height >= dropDownMenu2.MaximumSize.Height)
                {
                    timerNavigationMenu2.Stop();
                    expand2 = true;
                }
            }
            else
            {
                dropDownMenu2.Height -= 15;
                if (dropDownMenu2.Height <= dropDownMenu2.MinimumSize.Height)
                {
                    timerNavigationMenu2.Stop();
                    expand2 = false;
                }
            }
        }

        private void loadGreeting()
        {
            string pName = getName();
            lbHello.Text = pName;
        }

        private int getQuantityTeacher()
        {
            return gv_bll.getDataGiaoVien().Count;
        }

        public string getName()
        {
            string[] names = pHoTen.Split(' ');
            return names[names.Length - 2] + " " + names[names.Length - 1];
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
        }
    }
}
