namespace NILS_original
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel_loader = new System.Windows.Forms.Panel();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.btnRprt = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.picBxUser = new System.Windows.Forms.PictureBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelWaterMark = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel_loader.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.panel_loader);
            this.panel4.Name = "panel4";
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel_loader
            // 
            resources.ApplyResources(this.panel_loader, "panel_loader");
            this.panel_loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel_loader.Controls.Add(this.circularProgressBar1);
            this.panel_loader.Controls.Add(this.label2);
            this.panel_loader.Name = "panel_loader";
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 400;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.circularProgressBar1, "circularProgressBar1");
            this.circularProgressBar1.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar1.InnerColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.MarqueeAnimationSpeed = 1500;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.SystemColors.GrayText;
            this.circularProgressBar1.OuterMargin = -20;
            this.circularProgressBar1.OuterWidth = 8;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.White;
            this.circularProgressBar1.ProgressWidth = 25;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "%";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.UseWaitCursor = true;
            this.circularProgressBar1.Value = 68;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Turquoise;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button8);
            this.panel5.Controls.Add(this.button9);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.button14);
            this.panel5.Controls.Add(this.button16);
            this.panel5.Controls.Add(this.button13);
            this.panel5.Controls.Add(this.btnRprt);
            this.panel5.Controls.Add(this.button20);
            this.panel5.Controls.Add(this.button15);
            this.panel5.Controls.Add(this.button19);
            this.panel5.Controls.Add(this.button11);
            this.panel5.Name = "panel5";
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::NILS_original.Properties.Resources.icons8_meeting_room_64px_1;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::NILS_original.Properties.Resources.gmail_48px;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button8, "button8");
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Image = global::NILS_original.Properties.Resources.read_online_48px;
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.button9, "button9");
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Image = global::NILS_original.Properties.Resources.shutdown_48px;
            this.button9.Name = "button9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::NILS_original.Properties.Resources.user_50px;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button14.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button14, "button14");
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Image = global::NILS_original.Properties.Resources.timetable_48px;
            this.button14.Name = "button14";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button16.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button16, "button16");
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.Image = global::NILS_original.Properties.Resources.student_male_48px;
            this.button16.Name = "button16";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button13, "button13");
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Image = global::NILS_original.Properties.Resources.permanent_job_48px;
            this.button13.Name = "button13";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // btnRprt
            // 
            this.btnRprt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRprt.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnRprt, "btnRprt");
            this.btnRprt.ForeColor = System.Drawing.Color.White;
            this.btnRprt.Image = global::NILS_original.Properties.Resources.graph_report_48px;
            this.btnRprt.Name = "btnRprt";
            this.btnRprt.UseVisualStyleBackColor = false;
            this.btnRprt.Click += new System.EventHandler(this.btnRprt_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button20.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button20, "button20");
            this.button20.ForeColor = System.Drawing.Color.White;
            this.button20.Image = global::NILS_original.Properties.Resources.add_64px;
            this.button20.Name = "button20";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button15, "button15");
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Image = global::NILS_original.Properties.Resources.search_account_64px;
            this.button15.Name = "button15";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button19.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button19, "button19");
            this.button19.ForeColor = System.Drawing.Color.White;
            this.button19.Image = global::NILS_original.Properties.Resources.cash_in_hand_48px;
            this.button19.Name = "button19";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button11, "button11");
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Image = global::NILS_original.Properties.Resources.add_user_group_woman_man_skin_type_7_48px;
            this.button11.Name = "button11";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.picBxUser);
            this.panel7.Controls.Add(this.lblemail);
            this.panel7.Controls.Add(this.lblName);
            this.panel7.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Name = "panel7";
            // 
            // picBxUser
            // 
            resources.ApplyResources(this.picBxUser, "picBxUser");
            this.picBxUser.Name = "picBxUser";
            this.picBxUser.TabStop = false;
            this.picBxUser.Click += new System.EventHandler(this.picBxUser_Click);
            // 
            // lblemail
            // 
            resources.ApplyResources(this.lblemail, "lblemail");
            this.lblemail.BackColor = System.Drawing.Color.Transparent;
            this.lblemail.ForeColor = System.Drawing.Color.White;
            this.lblemail.Name = "lblemail";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Name = "lblName";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::NILS_original.Properties.Resources.nils_logo_jpg;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Name = "panel2";
            // 
            // labelWaterMark
            // 
            this.labelWaterMark.AutoEllipsis = true;
            this.labelWaterMark.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.labelWaterMark, "labelWaterMark");
            this.labelWaterMark.Name = "labelWaterMark";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.labelWaterMark);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel7);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(128)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel_loader.ResumeLayout(false);
            this.panel_loader.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Panel panel_loader;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.PictureBox picBxUser;
        public System.Windows.Forms.Label labelWaterMark;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button btnRprt;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

