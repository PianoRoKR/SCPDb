namespace SCPDb
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
            this.assignSCP_listBox = new System.Windows.Forms.ListBox();
            this.usersManaged_listBox = new System.Windows.Forms.ListBox();
            this.pbPic = new System.Windows.Forms.PictureBox();
            this.addUsers_listBox = new System.Windows.Forms.ListBox();
            this.lblSuper = new System.Windows.Forms.Label();
            this.buttonUserAdd = new System.Windows.Forms.Button();
            this.buttonUserEdit = new System.Windows.Forms.Button();
            this.buttonUserDelete = new System.Windows.Forms.Button();
            this.lblO5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
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
            this.buttonUserClassChange.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonUserClassChange, "buttonUserClassChange");
            this.buttonUserClassChange.Name = "buttonUserClassChange";
            this.buttonUserClassChange.UseVisualStyleBackColor = true;
            this.buttonUserClassChange.Click += new System.EventHandler(this.buttonUserChangeClass_Click);
            // 
            // buttonUserAssign
            // 
            this.buttonUserAssign.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonUserAssign, "buttonUserAssign");
            this.buttonUserAssign.Name = "buttonUserAssign";
            this.buttonUserAssign.UseVisualStyleBackColor = true;
            this.buttonUserAssign.Click += new System.EventHandler(this.buttonUserAssign_Click);
            // 
            // labelUser
            // 
            resources.ApplyResources(this.labelUser, "labelUser");
            this.labelUser.Name = "labelUser";
            // 
            // assignSCP_listBox
            // 
            this.assignSCP_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            resources.ApplyResources(this.assignSCP_listBox, "assignSCP_listBox");
            this.assignSCP_listBox.ForeColor = System.Drawing.SystemColors.Info;
            this.assignSCP_listBox.FormattingEnabled = true;
            this.assignSCP_listBox.Name = "assignSCP_listBox";
            // 
            // usersManaged_listBox
            // 
            this.usersManaged_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            resources.ApplyResources(this.usersManaged_listBox, "usersManaged_listBox");
            this.usersManaged_listBox.ForeColor = System.Drawing.SystemColors.Info;
            this.usersManaged_listBox.FormattingEnabled = true;
            this.usersManaged_listBox.Name = "usersManaged_listBox";
            // 
            // addUsers_listBox
            // 
            this.addUsers_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(75)))));
            resources.ApplyResources(this.addUsers_listBox, "addUsers_listBox");
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
            this.buttonUserAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonUserAdd, "buttonUserAdd");
            this.buttonUserAdd.Name = "buttonUserAdd";
            this.buttonUserAdd.UseVisualStyleBackColor = true;
            this.buttonUserAdd.Click += new System.EventHandler(this.buttonUserAdd_Click);
            // 
            // buttonUserEdit
            // 
            this.buttonUserEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonUserEdit, "buttonUserEdit");
            this.buttonUserEdit.Name = "buttonUserEdit";
            this.buttonUserEdit.UseVisualStyleBackColor = true;
            this.buttonUserEdit.Click += new System.EventHandler(this.buttonUserEdit_Click);
            // 
            // buttonUserDelete
            // 
            this.buttonUserDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonUserDelete, "buttonUserDelete");
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
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pbPic
            // 
            this.pbPic.Image = global::SCPDb.Properties.Resources.logo;
            resources.ApplyResources(this.pbPic, "pbPic");
            this.pbPic.Name = "pbPic";
            this.pbPic.TabStop = false;
            // 
            // userPortal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonUserDelete);
            this.Controls.Add(this.buttonUserEdit);
            this.Controls.Add(this.buttonUserAdd);
            this.Controls.Add(this.addUsers_listBox);
            this.Controls.Add(this.lblSuper);
            this.Controls.Add(this.pbPic);
            this.Controls.Add(this.usersManaged_listBox);
            this.Controls.Add(this.assignSCP_listBox);
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
        private System.Windows.Forms.ListBox assignSCP_listBox;
        private System.Windows.Forms.PictureBox pbPic;
        private System.Windows.Forms.ListBox addUsers_listBox;
        private System.Windows.Forms.Label lblSuper;
        private System.Windows.Forms.Button buttonUserAdd;
        private System.Windows.Forms.Button buttonUserEdit;
        private System.Windows.Forms.Button buttonUserDelete;
        private System.Windows.Forms.Label lblO5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}