namespace GUI.GroupAminGUI
{
    partial class frmAddDetailTeaching
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.btnFinish = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dgvDetailTeachingSchedule = new Guna.UI2.WinForms.Guna2DataGridView();
            this.bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel4 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.pv = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.cboLesson = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMaLD = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpThu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbDetail = new ReaLTaiizor.Controls.BigLabel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lbTitle = new ReaLTaiizor.Controls.BigLabel();
            this.lbLesson = new ReaLTaiizor.Controls.BigLabel();
            this.guna2GradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailTeachingSchedule)).BeginInit();
            this.pv.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnRemove.Location = new System.Drawing.Point(718, 280);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(227, 57);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "XÓA LỊCH";
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
            this.btnFinish.Location = new System.Drawing.Point(1025, 280);
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
            this.guna2GradientPanel3.Controls.Add(this.dgvDetailTeachingSchedule);
            this.guna2GradientPanel3.Location = new System.Drawing.Point(0, 360);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.guna2GradientPanel3.Size = new System.Drawing.Size(1330, 490);
            this.guna2GradientPanel3.TabIndex = 3;
            // 
            // dgvDetailTeachingSchedule
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvDetailTeachingSchedule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetailTeachingSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDetailTeachingSchedule.ColumnHeadersHeight = 40;
            this.dgvDetailTeachingSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetailTeachingSchedule.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetailTeachingSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailTeachingSchedule.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetailTeachingSchedule.Location = new System.Drawing.Point(10, 0);
            this.dgvDetailTeachingSchedule.MultiSelect = false;
            this.dgvDetailTeachingSchedule.Name = "dgvDetailTeachingSchedule";
            this.dgvDetailTeachingSchedule.ReadOnly = true;
            this.dgvDetailTeachingSchedule.RowHeadersVisible = false;
            this.dgvDetailTeachingSchedule.RowHeadersWidth = 51;
            this.dgvDetailTeachingSchedule.RowTemplate.Height = 24;
            this.dgvDetailTeachingSchedule.Size = new System.Drawing.Size(1310, 480);
            this.dgvDetailTeachingSchedule.TabIndex = 1;
            this.dgvDetailTeachingSchedule.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetailTeachingSchedule.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDetailTeachingSchedule.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDetailTeachingSchedule.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDetailTeachingSchedule.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDetailTeachingSchedule.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetailTeachingSchedule.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetailTeachingSchedule.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetailTeachingSchedule.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetailTeachingSchedule.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetailTeachingSchedule.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetailTeachingSchedule.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDetailTeachingSchedule.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDetailTeachingSchedule.ThemeStyle.ReadOnly = true;
            this.dgvDetailTeachingSchedule.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetailTeachingSchedule.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetailTeachingSchedule.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetailTeachingSchedule.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetailTeachingSchedule.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDetailTeachingSchedule.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetailTeachingSchedule.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // bigLabel3
            // 
            this.bigLabel3.AutoSize = true;
            this.bigLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel3.Location = new System.Drawing.Point(727, 151);
            this.bigLabel3.Name = "bigLabel3";
            this.bigLabel3.Size = new System.Drawing.Size(163, 28);
            this.bigLabel3.TabIndex = 0;
            this.bigLabel3.Text = "THỜI GIAN DẠY:";
            // 
            // bigLabel4
            // 
            this.bigLabel4.AutoSize = true;
            this.bigLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel4.Location = new System.Drawing.Point(96, 225);
            this.bigLabel4.Name = "bigLabel4";
            this.bigLabel4.Size = new System.Drawing.Size(100, 28);
            this.bigLabel4.TabIndex = 0;
            this.bigLabel4.Text = "TIẾT DẠY:";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(96, 151);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(97, 28);
            this.bigLabel1.TabIndex = 0;
            this.bigLabel1.Text = "MÃ LỊCH:";
            // 
            // pv
            // 
            this.pv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pv.Controls.Add(this.cboLesson);
            this.pv.Controls.Add(this.txtMaLD);
            this.pv.Controls.Add(this.btnRemove);
            this.pv.Controls.Add(this.btnFinish);
            this.pv.Controls.Add(this.guna2GradientPanel3);
            this.pv.Controls.Add(this.dtpThu);
            this.pv.Controls.Add(this.bigLabel3);
            this.pv.Controls.Add(this.lbDetail);
            this.pv.Controls.Add(this.bigLabel4);
            this.pv.Controls.Add(this.bigLabel1);
            this.pv.Controls.Add(this.lbLesson);
            this.pv.Controls.Add(this.lbTitle);
            this.pv.Location = new System.Drawing.Point(0, 42);
            this.pv.Name = "pv";
            this.pv.Size = new System.Drawing.Size(1330, 850);
            this.pv.TabIndex = 3;
            // 
            // cboLesson
            // 
            this.cboLesson.BackColor = System.Drawing.Color.Transparent;
            this.cboLesson.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLesson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLesson.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLesson.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLesson.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLesson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLesson.ItemHeight = 30;
            this.cboLesson.Location = new System.Drawing.Point(324, 217);
            this.cboLesson.Name = "cboLesson";
            this.cboLesson.Size = new System.Drawing.Size(284, 36);
            this.cboLesson.TabIndex = 6;
            // 
            // txtMaLD
            // 
            this.txtMaLD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaLD.DefaultText = "";
            this.txtMaLD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaLD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaLD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaLD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaLD.Enabled = false;
            this.txtMaLD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaLD.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaLD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtMaLD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaLD.Location = new System.Drawing.Point(324, 146);
            this.txtMaLD.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtMaLD.Name = "txtMaLD";
            this.txtMaLD.PasswordChar = '\0';
            this.txtMaLD.PlaceholderText = "";
            this.txtMaLD.SelectedText = "";
            this.txtMaLD.Size = new System.Drawing.Size(284, 36);
            this.txtMaLD.TabIndex = 5;
            // 
            // dtpThu
            // 
            this.dtpThu.BackColor = System.Drawing.Color.White;
            this.dtpThu.Checked = true;
            this.dtpThu.FillColor = System.Drawing.Color.White;
            this.dtpThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dtpThu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThu.Location = new System.Drawing.Point(965, 143);
            this.dtpThu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpThu.MinDate = new System.DateTime(2023, 9, 4, 0, 0, 0, 0);
            this.dtpThu.Name = "dtpThu";
            this.dtpThu.Size = new System.Drawing.Size(284, 36);
            this.dtpThu.TabIndex = 2;
            this.dtpThu.Value = new System.DateTime(2023, 9, 4, 0, 54, 0, 0);
            // 
            // lbDetail
            // 
            this.lbDetail.AutoSize = true;
            this.lbDetail.BackColor = System.Drawing.Color.Transparent;
            this.lbDetail.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetail.ForeColor = System.Drawing.Color.Red;
            this.lbDetail.Location = new System.Drawing.Point(96, 253);
            this.lbDetail.Name = "lbDetail";
            this.lbDetail.Size = new System.Drawing.Size(74, 25);
            this.lbDetail.TabIndex = 0;
            this.lbDetail.Text = "(Chi tiết)";
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
            this.guna2GradientPanel1.TabIndex = 2;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(65)))), ((int)(((byte)(102)))));
            this.lbTitle.Location = new System.Drawing.Point(94, 16);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1114, 57);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "CHI TIẾT KẾ HOẠCH PHÂN CÔNG GIÁO VIÊN LỚP 10A1";
            // 
            // lbLesson
            // 
            this.lbLesson.AutoSize = true;
            this.lbLesson.BackColor = System.Drawing.Color.Transparent;
            this.lbLesson.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLesson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbLesson.Location = new System.Drawing.Point(359, 73);
            this.lbLesson.Name = "lbLesson";
            this.lbLesson.Size = new System.Drawing.Size(531, 31);
            this.lbLesson.TabIndex = 0;
            this.lbLesson.Text = "MÔN : TOÁN - GIÁO VIÊN: PHẠM TRẦN TẤN ĐẠT";
            // 
            // frmAddDetailTeaching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 890);
            this.Controls.Add(this.pv);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddDetailTeaching";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddDetailTeaching";
            this.guna2GradientPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailTeachingSchedule)).EndInit();
            this.pv.ResumeLayout(false);
            this.pv.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private Guna.UI2.WinForms.Guna2Button btnFinish;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetailTeachingSchedule;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private ReaLTaiizor.Controls.BigLabel bigLabel4;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private Guna.UI2.WinForms.Guna2GradientPanel pv;
        private Guna.UI2.WinForms.Guna2TextBox txtMaLD;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ComboBox cboLesson;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpThu;
        private ReaLTaiizor.Controls.BigLabel lbDetail;
        private ReaLTaiizor.Controls.BigLabel lbTitle;
        private ReaLTaiizor.Controls.BigLabel lbLesson;
    }
}