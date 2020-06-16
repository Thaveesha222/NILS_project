namespace NILS_original
{
    partial class Admin_Update_Program
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
            this.cmb_type = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.cmb_module = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.tile_refresh = new MetroFramework.Controls.MetroTile();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.cmb_rperson1 = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbn_in = new MetroFramework.Controls.MetroRadioButton();
            this.rbn_out = new MetroFramework.Controls.MetroRadioButton();
            this.Venue = new MetroFramework.Controls.MetroLabel();
            this.tole_back = new MetroFramework.Controls.MetroTile();
            this.tile_clear = new MetroFramework.Controls.MetroTile();
            this.tile_enter = new MetroFramework.Controls.MetroTile();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.cmb_name = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cmb_rperson2 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txt_no = new MetroFramework.Controls.MetroTextBox();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txt_progtitle = new MetroFramework.Controls.MetroTextBox();
            this.cmb_rperson3 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.txt_venue = new System.Windows.Forms.ComboBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.cmb_batch = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_type
            // 
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.ItemHeight = 23;
            this.cmb_type.Items.AddRange(new object[] {
            "Diploma  Course",
            "Certificate Course",
            "One Day Course",
            "Two Day Course",
            "Three Day Course",
            "Workshop"});
            this.cmb_type.Location = new System.Drawing.Point(299, 98);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(323, 29);
            this.cmb_type.TabIndex = 98;
            this.cmb_type.UseSelectable = true;
            this.cmb_type.SelectedIndexChanged += new System.EventHandler(this.cmb_type_SelectedIndexChanged);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(41, 108);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(126, 19);
            this.metroLabel8.TabIndex = 97;
            this.metroLabel8.Text = "Select Course Type :";
            // 
            // cmb_module
            // 
            this.cmb_module.FormattingEnabled = true;
            this.cmb_module.ItemHeight = 23;
            this.cmb_module.Location = new System.Drawing.Point(299, 285);
            this.cmb_module.Name = "cmb_module";
            this.cmb_module.Size = new System.Drawing.Size(323, 29);
            this.cmb_module.TabIndex = 96;
            this.cmb_module.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(38, 297);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(99, 19);
            this.metroLabel7.TabIndex = 95;
            this.metroLabel7.Text = "Select Module :";
            // 
            // tile_refresh
            // 
            this.tile_refresh.ActiveControl = null;
            this.tile_refresh.Location = new System.Drawing.Point(1230, 667);
            this.tile_refresh.Name = "tile_refresh";
            this.tile_refresh.Size = new System.Drawing.Size(100, 48);
            this.tile_refresh.TabIndex = 94;
            this.tile_refresh.Text = "Refresh";
            this.tile_refresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tile_refresh.UseSelectable = true;
            this.tile_refresh.Click += new System.EventHandler(this.tile_refresh_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(38, 582);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(44, 19);
            this.metroLabel6.TabIndex = 93;
            this.metroLabel6.Text = "Venue";
            // 
            // cmb_rperson1
            // 
            this.cmb_rperson1.FormattingEnabled = true;
            this.cmb_rperson1.ItemHeight = 23;
            this.cmb_rperson1.Location = new System.Drawing.Point(299, 420);
            this.cmb_rperson1.Name = "cmb_rperson1";
            this.cmb_rperson1.Size = new System.Drawing.Size(323, 29);
            this.cmb_rperson1.TabIndex = 92;
            this.cmb_rperson1.UseSelectable = true;
            this.cmb_rperson1.SelectedIndexChanged += new System.EventHandler(this.cmb_rperson1_SelectedIndexChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbn_in);
            this.groupBox1.Controls.Add(this.rbn_out);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(299, 570);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 32);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbn_in
            // 
            this.rbn_in.AutoSize = true;
            this.rbn_in.Location = new System.Drawing.Point(6, 11);
            this.rbn_in.Name = "rbn_in";
            this.rbn_in.Size = new System.Drawing.Size(70, 15);
            this.rbn_in.TabIndex = 18;
            this.rbn_in.Text = "In-house";
            this.rbn_in.UseSelectable = true;
            this.rbn_in.CheckedChanged += new System.EventHandler(this.rbn_in_CheckedChanged);
            // 
            // rbn_out
            // 
            this.rbn_out.AutoSize = true;
            this.rbn_out.Location = new System.Drawing.Point(153, 11);
            this.rbn_out.Name = "rbn_out";
            this.rbn_out.Size = new System.Drawing.Size(79, 15);
            this.rbn_out.TabIndex = 19;
            this.rbn_out.Text = "Outstation";
            this.rbn_out.UseSelectable = true;
            this.rbn_out.CheckedChanged += new System.EventHandler(this.rbn_out_CheckedChanged);
            // 
            // Venue
            // 
            this.Venue.AutoSize = true;
            this.Venue.Location = new System.Drawing.Point(38, 628);
            this.Venue.Name = "Venue";
            this.Venue.Size = new System.Drawing.Size(108, 19);
            this.Venue.TabIndex = 89;
            this.Venue.Text = "Outstation Venue";
            // 
            // tole_back
            // 
            this.tole_back.ActiveControl = null;
            this.tole_back.Location = new System.Drawing.Point(493, 667);
            this.tole_back.Name = "tole_back";
            this.tole_back.Size = new System.Drawing.Size(100, 48);
            this.tole_back.TabIndex = 88;
            this.tole_back.Text = "Back";
            this.tole_back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tole_back.UseSelectable = true;
            // 
            // tile_clear
            // 
            this.tile_clear.ActiveControl = null;
            this.tile_clear.Location = new System.Drawing.Point(281, 667);
            this.tile_clear.Name = "tile_clear";
            this.tile_clear.Size = new System.Drawing.Size(100, 48);
            this.tile_clear.TabIndex = 87;
            this.tile_clear.Text = "Clear";
            this.tile_clear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tile_clear.UseSelectable = true;
            // 
            // tile_enter
            // 
            this.tile_enter.ActiveControl = null;
            this.tile_enter.Location = new System.Drawing.Point(38, 667);
            this.tile_enter.Name = "tile_enter";
            this.tile_enter.Size = new System.Drawing.Size(100, 48);
            this.tile_enter.TabIndex = 86;
            this.tile_enter.Text = "Enter";
            this.tile_enter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tile_enter.UseSelectable = true;
            this.tile_enter.Click += new System.EventHandler(this.tile_enter_Click);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.metroGrid1.Location = new System.Drawing.Point(792, 90);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(538, 522);
            this.metroGrid1.TabIndex = 85;
            this.metroGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellContentClick);
            // 
            // cmb_name
            // 
            this.cmb_name.FormattingEnabled = true;
            this.cmb_name.ItemHeight = 23;
            this.cmb_name.Location = new System.Drawing.Point(299, 239);
            this.cmb_name.Name = "cmb_name";
            this.cmb_name.Size = new System.Drawing.Size(323, 29);
            this.cmb_name.TabIndex = 84;
            this.cmb_name.UseSelectable = true;
            this.cmb_name.SelectedIndexChanged += new System.EventHandler(this.cmb_name_SelectedIndexChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(38, 251);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(91, 19);
            this.metroLabel5.TabIndex = 83;
            this.metroLabel5.Text = "Select Course:";
            // 
            // cmb_rperson2
            // 
            this.cmb_rperson2.Enabled = false;
            this.cmb_rperson2.FormattingEnabled = true;
            this.cmb_rperson2.ItemHeight = 23;
            this.cmb_rperson2.Location = new System.Drawing.Point(299, 466);
            this.cmb_rperson2.Name = "cmb_rperson2";
            this.cmb_rperson2.Size = new System.Drawing.Size(323, 29);
            this.cmb_rperson2.TabIndex = 82;
            this.cmb_rperson2.UseSelectable = true;
            this.cmb_rperson2.SelectedIndexChanged += new System.EventHandler(this.cmb_rperson2_SelectedIndexChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(36, 476);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(118, 19);
            this.metroLabel4.TabIndex = 81;
            this.metroLabel4.Text = "Resource Person-2";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(38, 430);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(116, 19);
            this.metroLabel3.TabIndex = 80;
            this.metroLabel3.Text = "Resource Person-1";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(38, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(69, 19);
            this.metroLabel2.TabIndex = 79;
            this.metroLabel2.Text = "Course no";
            // 
            // txt_no
            // 
            // 
            // 
            // 
            this.txt_no.CustomButton.Image = null;
            this.txt_no.CustomButton.Location = new System.Drawing.Point(80, 1);
            this.txt_no.CustomButton.Name = "";
            this.txt_no.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_no.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_no.CustomButton.TabIndex = 1;
            this.txt_no.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_no.CustomButton.UseSelectable = true;
            this.txt_no.CustomButton.Visible = false;
            this.txt_no.Lines = new string[0];
            this.txt_no.Location = new System.Drawing.Point(299, 60);
            this.txt_no.MaxLength = 32767;
            this.txt_no.Name = "txt_no";
            this.txt_no.PasswordChar = '\0';
            this.txt_no.ReadOnly = true;
            this.txt_no.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_no.SelectedText = "";
            this.txt_no.SelectionLength = 0;
            this.txt_no.SelectionStart = 0;
            this.txt_no.ShortcutsEnabled = true;
            this.txt_no.Size = new System.Drawing.Size(102, 23);
            this.txt_no.TabIndex = 78;
            this.txt_no.UseSelectable = true;
            this.txt_no.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_no.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Location = new System.Drawing.Point(299, 331);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(323, 29);
            this.metroDateTime1.TabIndex = 77;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(38, 343);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(100, 19);
            this.metroLabel1.TabIndex = 76;
            this.metroLabel1.Text = "Scheduled Date";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(38, 205);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(218, 19);
            this.metroLabel9.TabIndex = 99;
            this.metroLabel9.Text = "Program Title (Only for Workshops)";
            // 
            // txt_progtitle
            // 
            // 
            // 
            // 
            this.txt_progtitle.CustomButton.Image = null;
            this.txt_progtitle.CustomButton.Location = new System.Drawing.Point(301, 1);
            this.txt_progtitle.CustomButton.Name = "";
            this.txt_progtitle.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_progtitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_progtitle.CustomButton.TabIndex = 1;
            this.txt_progtitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_progtitle.CustomButton.UseSelectable = true;
            this.txt_progtitle.CustomButton.Visible = false;
            this.txt_progtitle.Enabled = false;
            this.txt_progtitle.Lines = new string[0];
            this.txt_progtitle.Location = new System.Drawing.Point(299, 199);
            this.txt_progtitle.MaxLength = 32767;
            this.txt_progtitle.Name = "txt_progtitle";
            this.txt_progtitle.PasswordChar = '\0';
            this.txt_progtitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_progtitle.SelectedText = "";
            this.txt_progtitle.SelectionLength = 0;
            this.txt_progtitle.SelectionStart = 0;
            this.txt_progtitle.ShortcutsEnabled = true;
            this.txt_progtitle.Size = new System.Drawing.Size(323, 23);
            this.txt_progtitle.TabIndex = 100;
            this.txt_progtitle.UseSelectable = true;
            this.txt_progtitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_progtitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmb_rperson3
            // 
            this.cmb_rperson3.Enabled = false;
            this.cmb_rperson3.FormattingEnabled = true;
            this.cmb_rperson3.ItemHeight = 23;
            this.cmb_rperson3.Location = new System.Drawing.Point(299, 519);
            this.cmb_rperson3.Name = "cmb_rperson3";
            this.cmb_rperson3.Size = new System.Drawing.Size(323, 29);
            this.cmb_rperson3.TabIndex = 102;
            this.cmb_rperson3.UseSelectable = true;
            this.cmb_rperson3.SelectedIndexChanged += new System.EventHandler(this.cmb_rperson3_SelectedIndexChanged);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(36, 529);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(118, 19);
            this.metroLabel10.TabIndex = 101;
            this.metroLabel10.Text = "Resource Person-3";
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(633, 480);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(62, 15);
            this.metroCheckBox1.TabIndex = 103;
            this.metroCheckBox1.Text = "Include";
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Location = new System.Drawing.Point(633, 533);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(62, 15);
            this.metroCheckBox2.TabIndex = 104;
            this.metroCheckBox2.Text = "Include";
            this.metroCheckBox2.UseSelectable = true;
            this.metroCheckBox2.CheckedChanged += new System.EventHandler(this.metroCheckBox2_CheckedChanged);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(792, 68);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(258, 19);
            this.metroLabel11.TabIndex = 105;
            this.metroLabel11.Text = "Click on record to view and update session";
            // 
            // txt_venue
            // 
            this.txt_venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_venue.FormattingEnabled = true;
            this.txt_venue.Location = new System.Drawing.Point(299, 619);
            this.txt_venue.Name = "txt_venue";
            this.txt_venue.Size = new System.Drawing.Size(389, 28);
            this.txt_venue.TabIndex = 107;
            this.txt_venue.SelectedIndexChanged += new System.EventHandler(this.txt_venue_SelectedIndexChanged);
            this.txt_venue.TextChanged += new System.EventHandler(this.txt_venue_TextChanged);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(38, 385);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(102, 19);
            this.metroLabel12.TabIndex = 108;
            this.metroLabel12.Text = "Scheduled Time";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(301, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Enabled = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(299, 381);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(323, 23);
            this.metroTextBox1.TabIndex = 109;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(41, 158);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(79, 19);
            this.metroLabel13.TabIndex = 110;
            this.metroLabel13.Text = "Select Batch";
            // 
            // cmb_batch
            // 
            this.cmb_batch.FormattingEnabled = true;
            this.cmb_batch.ItemHeight = 23;
            this.cmb_batch.Location = new System.Drawing.Point(299, 148);
            this.cmb_batch.Name = "cmb_batch";
            this.cmb_batch.Size = new System.Drawing.Size(475, 29);
            this.cmb_batch.TabIndex = 111;
            this.cmb_batch.UseSelectable = true;
            this.cmb_batch.SelectedIndexChanged += new System.EventHandler(this.cmb_batch_SelectedIndexChanged);
            // 
            // Admin_Update_Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 739);
            this.Controls.Add(this.cmb_batch);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txt_venue);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroCheckBox2);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.cmb_rperson3);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.txt_progtitle);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.cmb_type);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.cmb_module);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.tile_refresh);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.cmb_rperson1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Venue);
            this.Controls.Add(this.tole_back);
            this.Controls.Add(this.tile_clear);
            this.Controls.Add(this.tile_enter);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.cmb_name);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cmb_rperson2);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txt_no);
            this.Controls.Add(this.metroDateTime1);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Admin_Update_Program";
            this.Text = "Schedule Sessions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmb_type;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroComboBox cmb_module;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTile tile_refresh;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox cmb_rperson1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroRadioButton rbn_in;
        private MetroFramework.Controls.MetroRadioButton rbn_out;
        private MetroFramework.Controls.MetroLabel Venue;
        private MetroFramework.Controls.MetroTile tole_back;
        private MetroFramework.Controls.MetroTile tile_clear;
        private MetroFramework.Controls.MetroTile tile_enter;
        public MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroComboBox cmb_name;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cmb_rperson2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txt_no;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txt_progtitle;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        public MetroFramework.Controls.MetroComboBox cmb_rperson3;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        public System.Windows.Forms.ComboBox txt_venue;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroComboBox cmb_batch;
    }
}