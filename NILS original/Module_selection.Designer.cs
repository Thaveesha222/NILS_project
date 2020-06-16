namespace NILS_original
{
    partial class Module_selection
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lbl_stud_no = new MetroFramework.Controls.MetroLabel();
            this.lbl_course_no = new MetroFramework.Controls.MetroLabel();
            this.lbl_course_name = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.lbl_min_mods = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(30, 303);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(521, 298);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck_1);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(30, 255);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(211, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Please select Modules From Below";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(31, 634);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(128, 58);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "Confirm and Add";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Location = new System.Drawing.Point(424, 634);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(128, 58);
            this.metroTile3.TabIndex = 4;
            this.metroTile3.Text = "Close";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(31, 64);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(71, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Stude no -";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(31, 111);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(82, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Course No -";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(31, 161);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(100, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Course Name -";
            // 
            // lbl_stud_no
            // 
            this.lbl_stud_no.AutoSize = true;
            this.lbl_stud_no.Location = new System.Drawing.Point(149, 63);
            this.lbl_stud_no.Name = "lbl_stud_no";
            this.lbl_stud_no.Size = new System.Drawing.Size(83, 19);
            this.lbl_stud_no.TabIndex = 8;
            this.lbl_stud_no.Text = "metroLabel5";
            this.lbl_stud_no.Click += new System.EventHandler(this.lbl_stud_no_Click);
            // 
            // lbl_course_no
            // 
            this.lbl_course_no.AutoSize = true;
            this.lbl_course_no.Location = new System.Drawing.Point(149, 111);
            this.lbl_course_no.Name = "lbl_course_no";
            this.lbl_course_no.Size = new System.Drawing.Size(83, 19);
            this.lbl_course_no.TabIndex = 9;
            this.lbl_course_no.Text = "metroLabel6";
            // 
            // lbl_course_name
            // 
            this.lbl_course_name.AutoSize = true;
            this.lbl_course_name.Location = new System.Drawing.Point(149, 161);
            this.lbl_course_name.Name = "lbl_course_name";
            this.lbl_course_name.Size = new System.Drawing.Size(83, 19);
            this.lbl_course_name.TabIndex = 10;
            this.lbl_course_name.Text = "metroLabel7";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(30, 281);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(271, 19);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "(Checked modules are compulsory modules)";
            // 
            // lbl_min_mods
            // 
            this.lbl_min_mods.AutoSize = true;
            this.lbl_min_mods.Location = new System.Drawing.Point(302, 207);
            this.lbl_min_mods.Name = "lbl_min_mods";
            this.lbl_min_mods.Size = new System.Drawing.Size(83, 19);
            this.lbl_min_mods.TabIndex = 13;
            this.lbl_min_mods.Text = "metroLabel7";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(31, 207);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(247, 19);
            this.metroLabel7.TabIndex = 12;
            this.metroLabel7.Text = "Minimum number of modules to select -";
            // 
            // Module_selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 711);
            this.Controls.Add(this.lbl_min_mods);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.lbl_course_name);
            this.Controls.Add(this.lbl_course_no);
            this.Controls.Add(this.lbl_stud_no);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Module_selection";
            this.Text = "Module selection";
            this.Load += new System.EventHandler(this.Module_selection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLabel lbl_stud_no;
        public MetroFramework.Controls.MetroLabel lbl_course_no;
        private MetroFramework.Controls.MetroLabel lbl_course_name;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel lbl_min_mods;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        public MetroFramework.Controls.MetroTile metroTile1;
    }
}