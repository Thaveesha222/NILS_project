namespace NILS_original
{
    partial class Add_Student_Mark
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_choosefile = new System.Windows.Forms.TextBox();
            this.txt_Load = new System.Windows.Forms.TextBox();
            this.btn_clear = new MetroFramework.Controls.MetroTile();
            this.btn_update = new MetroFramework.Controls.MetroTile();
            this.txtBtnUpload = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(96, 275);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1007, 574);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txt_choosefile
            // 
            this.txt_choosefile.Enabled = false;
            this.txt_choosefile.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_choosefile.Location = new System.Drawing.Point(317, 171);
            this.txt_choosefile.Name = "txt_choosefile";
            this.txt_choosefile.Size = new System.Drawing.Size(583, 28);
            this.txt_choosefile.TabIndex = 51;
            this.txt_choosefile.TextChanged += new System.EventHandler(this.txt_choosefile_TextChanged);
            // 
            // txt_Load
            // 
            this.txt_Load.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Load.Location = new System.Drawing.Point(317, 223);
            this.txt_Load.Name = "txt_Load";
            this.txt_Load.Size = new System.Drawing.Size(348, 28);
            this.txt_Load.TabIndex = 52;
            // 
            // btn_clear
            // 
            this.btn_clear.ActiveControl = null;
            this.btn_clear.AutoSize = true;
            this.btn_clear.Location = new System.Drawing.Point(96, 213);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(184, 47);
            this.btn_clear.TabIndex = 45;
            this.btn_clear.Text = "LOAD";
            this.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //this.btn_clear.TileImage = global::NILS_original.Properties.Resources.submit_progress_48px;
            this.btn_clear.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear.UseSelectable = true;
            this.btn_clear.UseTileImage = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_update
            // 
            this.btn_update.ActiveControl = null;
            this.btn_update.AutoSize = true;
            this.btn_update.Location = new System.Drawing.Point(96, 163);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(184, 46);
            this.btn_update.TabIndex = 42;
            this.btn_update.Text = "CHOOSE FILE";
            this.btn_update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // this.btn_update.TileImage = global::NILS_original.Properties.Resources.opened_folder_48px;
            this.btn_update.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update.UseSelectable = true;
            this.btn_update.UseTileImage = true;
            this.btn_update.Click += new System.EventHandler(this.btn_cal_Click);
            // 
            // txtBtnUpload
            // 
            this.txtBtnUpload.Location = new System.Drawing.Point(851, 225);
            this.txtBtnUpload.Name = "txtBtnUpload";
            this.txtBtnUpload.Size = new System.Drawing.Size(123, 35);
            this.txtBtnUpload.TabIndex = 53;
            this.txtBtnUpload.Text = "Upload";
            this.txtBtnUpload.UseSelectable = true;
            this.txtBtnUpload.Click += new System.EventHandler(this.txtBtnUpload_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(980, 223);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(123, 35);
            this.metroButton1.TabIndex = 54;
            this.metroButton1.Text = "Refresh";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Add_Student_Mark
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1174, 756);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtBtnUpload);
            this.Controls.Add(this.txt_Load);
            this.Controls.Add(this.txt_choosefile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_update);
            this.Name = "Add_Student_Mark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Add_Student_Mark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile btn_update;
        private MetroFramework.Controls.MetroTile btn_clear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_choosefile;
        private System.Windows.Forms.TextBox txt_Load;
        private MetroFramework.Controls.MetroButton txtBtnUpload;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}