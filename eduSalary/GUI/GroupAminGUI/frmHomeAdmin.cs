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

namespace GUI.GroupAminGUI
{
    public partial class frmHomeAdmin : Form
    {
        private string pHoTen;

        GiaoVienBLL gv_bll = new GiaoVienBLL();
        LopHocBLL lp_bll = new LopHocBLL();

        public frmHomeAdmin()
        {
            InitializeComponent();
            this.Load += FrmHomeAdmin_Load;

            timerClock = new Timer();
            timerClock.Interval = 1000;
            timerClock.Tick += TimerClock_Tick; 
            timerClock.Start(); 
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            UpdateTime();
            UpdateDate();
        }

        private void FrmHomeAdmin_Load(object sender, EventArgs e)
        {
            UpdateTime();

            loadGreeting();
            setPicTime();
            lbQuantityTeacher.Text = getQuantityTeacher().ToString();
            lbQuantityClassroom.Text = getQuantityClassroom().ToString();
        }

        private void loadGreeting()
        {
            lbHello.Text = timeHi();
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
            return pHi.ToUpper();
        }

        public void setPicTime()
        {
            int pHours = DateTime.Now.Hour; ;

            if (pHours >= 4 && pHours < 13)
            {
                picTime.Image = Properties.Resources.morning;
            }
            else if (pHours >= 13 && pHours < 18)
            {
                picTime.Image = Properties.Resources.afternoon;
            }
            else
            {
                picTime.Image = Properties.Resources.night;
            }
        }

        private int getQuantityTeacher()
        {
            return gv_bll.getDataGiaoVien().Count;
        }

        private int getQuantityClassroom()
        {
            return lp_bll.getDataLopHoc().Count;
        }

        private void UpdateTime()
        {
            DateTime currentTime = DateTime.Now;
            lbClock.Text = currentTime.ToString("HH:mm tt");
        }

        private void UpdateDate()
        {
            DateTime currentDate = DateTime.Now;
            lbDate.Text = currentDate.ToString("dd/MM/yyyy");
        }
    }
}
