using GUI.GroupTeacherGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLoading : MetroFramework.Forms.MetroForm
    {
        string pCode, pPass;

        public frmLoading(string Code, string Pass)
        {
            InitializeComponent();
            timerLoading = new Timer();
            timerLoading.Interval = 10;
            timerLoading.Enabled = true;
            timerLoading.Tick += TimerLoading_Tick;
            pCode = Code;
            pPass = Pass;
        }

        private void TimerLoading_Tick(object sender, EventArgs e)
        {
            timeLine.Width += 3;
            if (timeLine.Width >= 525)
            {
                timerLoading.Stop();
                frmMainTeacher fMainTeacher = new frmMainTeacher(pCode, pPass);
                fMainTeacher.Show();
                this.Close();
            }
        }
    }
}
