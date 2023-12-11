namespace GUI.GroupAminGUI
{
    partial class frmAddTeaching
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pv = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnFinish = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dtpTGKT = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpTGBD = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboTenGV = new Guna.UI2.WinForms.Guna2ComboBox();
            this.bigLabel5 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
            this.cboMH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            this.lbTenLP = new ReaLTaiizor.Controls.BigLabel();
            this.dgvTeachingSchedule = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            this.pv.SuspendLayout();
            this.guna2GradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachingSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel1.Controls.Add(this.guna2ControlBox1);
            this.guna2GradientPanel1.Controls.Add(this.btnExit);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(65)))), ((int)(((byte)(102)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(65)))), ((int)(((byte)(102)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, -2);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1330, 45);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Animated = true;
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(65)))), ((int)(((byte)(102)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1210, 0);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(60, 45);
            this.guna2ControlBox1.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Animated = true;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(65)))), ((int)(((byte)(102)))));
            this.btnExit.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnExit.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.btnExit.Location = new System.Drawing.Point(1270, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 45);
            this.btnExit.TabIndex = 6;
            // 
            // pv
            // 
            this.pv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pv.Controls.Add(this.btnRemove);
            this.pv.Controls.Add(this.btnFinish);
            this.pv.Controls.Add(this.guna2GradientPanel3);
            this.pv.Controls.Add(this.dtpTGKT);
            this.pv.Controls.Add(this.dtpTGBD);
            this.pv.Controls.Add(this.cboTenGV);
            this.pv.Controls.Add(this.bigLabel5);
            this.pv.Controls.Add(this.bigLabel3);
            this.pv.Controls.Add(this.bigLabel4);
            this.pv.Controls.Add(this.cboMH);
            this.pv.Controls.Add(this.bigLabel1);
            this.pv.Controls.Add(this.bigLabel2);
            this.pv.Controls.Add(this.lbTenLP);
            this.pv.Location = new System.Drawing.Point(0, 42);
            this.pv.Name = "pv";
            this.pv.Size = new System.Drawing.Size(1330, 850);
            this.pv.TabIndex = 1;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BorderRadius = 15;
            this.btnFinish.CustomizableEdges.BottomLeft = false;
            this.btnFinish.CustomizableEdges.TopRight = false;
            this.btnFinish.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFinish.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFinish.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFinish.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFinish.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(1025, 265);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(227, 57);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "LẬP LỊCH";
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel3.Controls.Add(this.dgvTeachingSchedule);
            this.guna2GradientPanel3.Location = new System.Drawing.Point(0, 360);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.guna2GradientPanel3.Size = new System.Drawing.Size(1330, 490);
            this.guna2GradientPanel3.TabIndex = 3;
            // 
            // dtpTGKT
            // 
            this.dtpTGKT.BackColor = System.Drawing.Color.White;
            this.dtpTGKT.Checked = true;
            this.dtpTGKT.FillColor = System.Drawing.Color.White;
            this.dtpTGKT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTGKT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dtpTGKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTGKT.Location = new System.Drawing.Point(968, 175);
            this.dtpTGKT.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTGKT.MinDate = new System.DateTime(2023, 9, 4, 0, 0, 0, 0);
            this.dtpTGKT.Name = "dtpTGKT";
            this.dtpTGKT.Size = new System.Drawing.Size(284, 36);
            this.dtpTGKT.TabIndex = 2;
            this.dtpTGKT.Value = new System.DateTime(2023, 12, 8, 0, 54, 1, 230);
            // 
            // dtpTGBD
            // 
            this.dtpTGBD.BackColor = System.Drawing.Color.White;
            this.dtpTGBD.Checked = true;
            this.dtpTGBD.FillColor = System.Drawing.Color.White;
            this.dtpTGBD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTGBD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dtpTGBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTGBD.Location = new System.Drawing.Point(327, 175);
            this.dtpTGBD.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTGBD.MinDate = new System.DateTime(2023, 9, 4, 0, 0, 0, 0);
            this.dtpTGBD.Name = "dtpTGBD";
            this.dtpTGBD.Size = new System.Drawing.Size(284, 36);
            this.dtpTGBD.TabIndex = 2;
            this.dtpTGBD.Value = new System.DateTime(2023, 9, 4, 0, 54, 0, 0);
            // 
            // cboTenGV
            // 
            this.cboTenGV.BackColor = System.Drawing.Color.Transparent;
            this.cboTenGV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTenGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenGV.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenGV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenGV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTenGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cboTenGV.ItemHeight = 30;
            this.cboTenGV.Location = new System.Drawing.Point(968, 104);
            this.cboTenGV.Name = "cboTenGV";
            this.cboTenGV.Size = new System.Drawing.Size(284, 36);
            this.cboTenGV.TabIndex = 1;
            // 
            // bigLabel5
            // 
            this.bigLabel5.AutoSize = true;
            this.bigLabel5.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel5.Location = new System.Drawing.Point(730, 183);
            this.bigLabel5.Name = "bigLabel5";
            this.bigLabel5.Size = new System.Drawing.Size(215, 28);
            this.bigLabel5.TabIndex = 0;
            this.bigLabel5.Text = "THỜI GIAN KẾT THÚC:";
            // 
            // bigLabel3
            // 
            this.bigLabel3.AutoSize = true;
            this.bigLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel3.Location = new System.Drawing.Point(730, 109);
            this.bigLabel3.Name = "bigLabel3";
            this.bigLabel3.Size = new System.Drawing.Size(115, 28);
            this.bigLabel3.TabIndex = 0;
            this.bigLabel3.Text = "GIÁO VIÊN:";
            // 
            // bigLabel4
            // 
            this.bigLabel4.AutoSize = true;
            this.bigLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel4.Location = new System.Drawing.Point(99, 183);
            this.bigLabel4.Name = "bigLabel4";
            this.bigLabel4.Size = new System.Drawing.Size(207, 28);
            this.bigLabel4.TabIndex = 0;
            this.bigLabel4.Text = "THỜI GIAN BẮT ĐẦU:";
            // 
            // cboMH
            // 
            this.cboMH.BackColor = System.Drawing.Color.Transparent;
            this.cboMH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMH.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cboMH.ItemHeight = 30;
            this.cboMH.Location = new System.Drawing.Point(327, 104);
            this.cboMH.Name = "cboMH";
            this.cboMH.Size = new System.Drawing.Size(284, 36);
            this.cboMH.TabIndex = 1;
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(99, 109);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(113, 28);
            this.bigLabel1.TabIndex = 0;
            this.bigLabel1.Text = "MÔN HỌC:";
            // 
            // bigLabel2
            // 
            this.bigLabel2.AutoSize = true;
            this.bigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel2.Font = new System.Drawing.Font("Segoe UI", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(65)))), ((int)(((byte)(102)))));
            this.bigLabel2.Location = new System.Drawing.Point(167, 13);
            this.bigLabel2.Name = "bigLabel2";
            this.bigLabel2.Size = new System.Drawing.Size(820, 57);
            this.bigLabel2.TabIndex = 0;
            this.bigLabel2.Text = "KẾ HOẠCH PHÂN CÔNG GIÁO VIÊN LỚP";
            // 
            // lbTenLP
            // 
            this.lbTenLP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTenLP.AutoSize = true;
            this.lbTenLP.BackColor = System.Drawing.Color.Transparent;
            this.lbTenLP.Font = new System.Drawing.Font("Segoe UI", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenLP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(65)))), ((int)(((byte)(102)))));
            this.lbTenLP.Location = new System.Drawing.Point(1031, 13);
            this.lbTenLP.Name = "lbTenLP";
            this.lbTenLP.Size = new System.Drawing.Size(127, 57);
            this.lbTenLP.TabIndex = 0;
            this.lbTenLP.Text = "10A1";
            // 
            // dgvTeachingSchedule
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvTeachingSchedule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeachingSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTeachingSchedule.ColumnHeadersHeight = 40;
            this.dgvTeachingSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeachingSchedule.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTeachingSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTeachingSchedule.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeachingSchedule.Location = new System.Drawing.Point(10, 0);
            this.dgvTeachingSchedule.MultiSelect = false;
            this.dgvTeachingSchedule.Name = "dgvTeachingSchedule";
            this.dgvTeachingSchedule.ReadOnly = true;
            this.dgvTeachingSchedule.RowHeadersVisible = false;
            this.dgvTeachingSchedule.RowHeadersWidth = 51;
            this.dgvTeachingSchedule.RowTemplate.Height = 24;
            this.dgvTeachingSchedule.Size = new System.Drawing.Size(1310, 480);
            this.dgvTeachingSchedule.TabIndex = 1;
            this.dgvTeachingSchedule.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeachingSchedule.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTeachingSchedule.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTeachingSchedule.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTeachingSchedule.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTeachingSchedule.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeachingSchedule.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeachingSchedule.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTeachingSchedule.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTeachingSchedule.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachingSchedule.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTeachingSchedule.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTeachingSchedule.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvTeachingSchedule.ThemeStyle.ReadOnly = true;
            this.dgvTeachingSchedule.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeachingSchedule.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTeachingSchedule.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachingSchedule.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTeachingSchedule.ThemeStyle.RowsStyle.Height = 24;
            this.dgvTeachingSchedule.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeachingSchedule.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BorderRadius = 15;
            this.btnRemove.CustomizableEdges.BottomLeft = false;
            this.btnRemove.CustomizableEdges.TopRight = false;
            this.btnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemove.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(65)))), ((int)(((byte)(102)))));
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(718, 265);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(227, 57);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "XÓA LỊCH";
            // 
            // frmAddTeaching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 890);
            this.Controls.Add(this.pv);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddTeaching";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddTeaching";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.pv.ResumeLayout(false);
            this.pv.PerformLayout();
            this.guna2GradientPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachingSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private Guna.UI2.WinForms.Guna2GradientPanel pv;
        private ReaLTaiizor.Controls.BigLabel lbTenLP;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cboTenGV;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private Guna.UI2.WinForms.Guna2ComboBox cboMH;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTGBD;
        private ReaLTaiizor.Controls.BigLabel bigLabel5;
        private ReaLTaiizor.Controls.BigLabel bigLabel4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTGKT;
        private Guna.UI2.WinForms.Guna2Button btnFinish;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTeachingSchedule;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
    }
}