﻿namespace SCPDb
{
    partial class userPortal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userPortal));
            this.agentWelcome_label = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.Button();
            this.agentClass = new System.Windows.Forms.Label();
            this.labelAss = new System.Windows.Forms.Label();
            this.buttonSCPAdd = new System.Windows.Forms.Button();
            this.buttonSCPEdit = new System.Windows.Forms.Button();
            this.buttonSCPView = new System.Windows.Forms.Button();
            this.buttonUserClassChange = new System.Windows.Forms.Button();
            this.buttonUserAssign = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.viewSCP_listBox = new System.Windows.Forms.ListBox();
            this.usersManaged_listBox = new System.Windows.Forms.ListBox();
            this.addUsers_listBox = new System.Windows.Forms.ListBox();
            this.lblSuper = new System.Windows.Forms.Label();
            this.buttonUserAdd = new System.Windows.Forms.Button();
            this.buttonUserEdit = new System.Windows.Forms.Button();
            this.buttonUserDelete = new System.Windows.Forms.Button();
            this.lblO5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.pbPic = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.assignSCP_listBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // agentWelcome_label
            // 
            resources.ApplyResources(this.agentWelcome_label, "agentWelcome_label");
            this.agentWelcome_label.Name = "agentWelcome_label";
            // 
            // logout
            // 
            resources.ApplyResources(this.logout, "logout");
            this.logout.Name = "logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // agentClass
            // 
            resources.ApplyResources(this.agentClass, "agentClass");
            this.agentClass.Name = "agentClass";
            // 
            // labelAss
            // 
            resources.ApplyResources(this.labelAss, "labelAss");
            this.labelAss.Name = "labelAss";
            // 
            // buttonSCPAdd
            // 
            this.buttonSCPAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonSCPAdd, "buttonSCPAdd");
            this.buttonSCPAdd.Name = "buttonSCPAdd";
            this.buttonSCPAdd.UseVisualStyleBackColor = true;
            this.buttonSCPAdd.Click += new System.EventHandler(this.buttonSCPAdd_Click);
            // 
            // buttonSCPEdit
            // 
            this.buttonSCPEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonSCPEdit, "buttonSCPEdit");
            this.buttonSCPEdit.Name = "buttonSCPEdit";
            this.buttonSCPEdit.UseVisualStyleBackColor = true;
            this.buttonSCPEdit.Click += new System.EventHandler(this.buttonSCPEdit_Click);
            // 
            // buttonSCPView
            // 
            this.buttonSCPView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonSCPView, "buttonSCPView");
            this.buttonSCPView.Name = "buttonSCPView";
            this.buttonSCPView.UseVisualStyleBackColor = true;
            this.buttonSCPView.Click += new System.EventHandler(this.buttonSCPView_Click);
            // 
            // buttonUserClassChange
            // 
            resources.ApplyResources(this.buttonUserClassChange, "buttonUserClassChange");
            this.buttonUserClassChange.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonUserClassChange.Name = "buttonUserClassChange";
            this.buttonUserClassChange.UseVisualStyleBackColor = true;
            this.buttonUserClassChange.Click += new System.EventHandler(this.buttonUserChangeClass_Click);
            // 
            // buttonUserAssign
            // 
            resources.ApplyResources(this.buttonUserAssign, "buttonUserAssign");
            this.buttonUserAssign.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonUserAssign.Name = "buttonUserAssign";
            this.buttonUserAssign.UseVisualStyleBackColor = true;
            this.buttonUserAssign.Click += new System.EventHandler(this.buttonUserAssign_Click);
            // 
            // labelUser
            // 
            resources.ApplyResources(this.labelUser, "labelUser");
            this.labelUser.Name = "labelUser";
            // 
            // viewSCP_listBox
            // 
            this.viewSCP_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            resources.ApplyResources(this.viewSCP_listBox, "viewSCP_listBox");
            this.viewSCP_listBox.ForeColor = System.Drawing.SystemColors.Info;
            this.viewSCP_listBox.FormattingEnabled = true;
            this.viewSCP_listBox.Name = "viewSCP_listBox";
            // 
            // usersManaged_listBox
            // 
            resources.ApplyResources(this.usersManaged_listBox, "usersManaged_listBox");
            this.usersManaged_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            this.usersManaged_listBox.ForeColor = System.Drawing.SystemColors.Info;
            this.usersManaged_listBox.FormattingEnabled = true;
            this.usersManaged_listBox.Name = "usersManaged_listBox";
            // 
            // addUsers_listBox
            // 
            resources.ApplyResources(this.addUsers_listBox, "addUsers_listBox");
            this.addUsers_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            this.addUsers_listBox.ForeColor = System.Drawing.SystemColors.Info;
            this.addUsers_listBox.FormattingEnabled = true;
            this.addUsers_listBox.Name = "addUsers_listBox";
            // 
            // lblSuper
            // 
            resources.ApplyResources(this.lblSuper, "lblSuper");
            this.lblSuper.Name = "lblSuper";
            // 
            // buttonUserAdd
            // 
            resources.ApplyResources(this.buttonUserAdd, "buttonUserAdd");
            this.buttonUserAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonUserAdd.Name = "buttonUserAdd";
            this.buttonUserAdd.UseVisualStyleBackColor = true;
            this.buttonUserAdd.Click += new System.EventHandler(this.buttonUserAdd_Click);
            // 
            // buttonUserEdit
            // 
            resources.ApplyResources(this.buttonUserEdit, "buttonUserEdit");
            this.buttonUserEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonUserEdit.Name = "buttonUserEdit";
            this.buttonUserEdit.UseVisualStyleBackColor = true;
            this.buttonUserEdit.Click += new System.EventHandler(this.buttonUserEdit_Click);
            // 
            // buttonUserDelete
            // 
            resources.ApplyResources(this.buttonUserDelete, "buttonUserDelete");
            this.buttonUserDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonUserDelete.Name = "buttonUserDelete";
            this.buttonUserDelete.UseVisualStyleBackColor = true;
            this.buttonUserDelete.Click += new System.EventHandler(this.buttonUserDelete_Click);
            // 
            // lblO5
            // 
            resources.ApplyResources(this.lblO5, "lblO5");
            this.lblO5.Name = "lblO5";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonRemove
            // 
            resources.ApplyResources(this.buttonRemove, "buttonRemove");
            this.buttonRemove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // pbPic
            // 
            resources.ApplyResources(this.pbPic, "pbPic");
            this.pbPic.Image = global::SCPDb.Properties.Resources.logo;
            this.pbPic.Name = "pbPic";
            this.pbPic.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            this.tabPage1.Controls.Add(this.assignSCP_listBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // assignSCP_listBox
            // 
            this.assignSCP_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            resources.ApplyResources(this.assignSCP_listBox, "assignSCP_listBox");
            this.assignSCP_listBox.ForeColor = System.Drawing.SystemColors.Info;
            this.assignSCP_listBox.FormattingEnabled = true;
            this.assignSCP_listBox.Name = "assignSCP_listBox";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            this.tabPage2.Controls.Add(this.viewSCP_listBox);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // buttonChangePassword
            // 
            resources.ApplyResources(this.buttonChangePassword, "buttonChangePassword");
            this.buttonChangePassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // userPortal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonUserDelete);
            this.Controls.Add(this.buttonUserEdit);
            this.Controls.Add(this.buttonUserAdd);
            this.Controls.Add(this.addUsers_listBox);
            this.Controls.Add(this.lblSuper);
            this.Controls.Add(this.pbPic);
            this.Controls.Add(this.usersManaged_listBox);
            this.Controls.Add(this.buttonUserClassChange);
            this.Controls.Add(this.buttonUserAssign);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.buttonSCPView);
            this.Controls.Add(this.buttonSCPEdit);
            this.Controls.Add(this.buttonSCPAdd);
            this.Controls.Add(this.labelAss);
            this.Controls.Add(this.agentClass);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.agentWelcome_label);
            this.Controls.Add(this.lblO5);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "userPortal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.userPortal_FormClosing);
            this.Load += new System.EventHandler(this.userPortal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label agentWelcome_label;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label agentClass;
        private System.Windows.Forms.Label labelAss;
        private System.Windows.Forms.Button buttonSCPAdd;
        private System.Windows.Forms.Button buttonSCPEdit;
        private System.Windows.Forms.Button buttonSCPView;
        private System.Windows.Forms.Button buttonUserClassChange;
        private System.Windows.Forms.Button buttonUserAssign;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.ListBox usersManaged_listBox;
        private System.Windows.Forms.ListBox viewSCP_listBox;
        private System.Windows.Forms.PictureBox pbPic;
        private System.Windows.Forms.ListBox addUsers_listBox;
        private System.Windows.Forms.Label lblSuper;
        private System.Windows.Forms.Button buttonUserAdd;
        private System.Windows.Forms.Button buttonUserEdit;
        private System.Windows.Forms.Button buttonUserDelete;
        private System.Windows.Forms.Label lblO5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.ListBox assignSCP_listBox;
    }
}