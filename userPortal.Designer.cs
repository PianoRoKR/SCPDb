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
            this.comboAss = new System.Windows.Forms.ComboBox();
            this.buttonSCPAdd = new System.Windows.Forms.Button();
            this.buttonSCPEdit = new System.Windows.Forms.Button();
            this.buttonSCPView = new System.Windows.Forms.Button();
            this.buttonUserView = new System.Windows.Forms.Button();
            this.buttonUserEdit = new System.Windows.Forms.Button();
            this.comboUser = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
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
            // comboAss
            // 
            this.comboAss.FormattingEnabled = true;
            resources.ApplyResources(this.comboAss, "comboAss");
            this.comboAss.Name = "comboAss";
            this.comboAss.SelectedIndexChanged += new System.EventHandler(this.comboAss_SelectedIndexChanged);
            // 
            // buttonSCPAdd
            // 
            this.buttonSCPAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonSCPAdd, "buttonSCPAdd");
            this.buttonSCPAdd.Name = "buttonSCPAdd";
            this.buttonSCPAdd.UseVisualStyleBackColor = true;
            // 
            // buttonSCPEdit
            // 
            this.buttonSCPEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonSCPEdit, "buttonSCPEdit");
            this.buttonSCPEdit.Name = "buttonSCPEdit";
            this.buttonSCPEdit.UseVisualStyleBackColor = true;
            this.buttonSCPEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonSCPView
            // 
            this.buttonSCPView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.buttonSCPView, "buttonSCPView");
            this.buttonSCPView.Name = "buttonSCPView";
            this.buttonSCPView.UseVisualStyleBackColor = true;
            // 
            // buttonUserView
            // 
            resources.ApplyResources(this.buttonUserView, "buttonUserView");
            this.buttonUserView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonUserView.Name = "buttonUserView";
            this.buttonUserView.UseVisualStyleBackColor = true;
            this.buttonUserView.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonUserEdit
            // 
            resources.ApplyResources(this.buttonUserEdit, "buttonUserEdit");
            this.buttonUserEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonUserEdit.Name = "buttonUserEdit";
            this.buttonUserEdit.UseVisualStyleBackColor = true;
            this.buttonUserEdit.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboUser
            // 
            resources.ApplyResources(this.comboUser, "comboUser");
            this.comboUser.FormattingEnabled = true;
            this.comboUser.Name = "comboUser";
            this.comboUser.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelUser
            // 
            resources.ApplyResources(this.labelUser, "labelUser");
            this.labelUser.Name = "labelUser";
            this.labelUser.Click += new System.EventHandler(this.label1_Click);
            // 
            // userPortal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.buttonUserView);
            this.Controls.Add(this.buttonUserEdit);
            this.Controls.Add(this.comboUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.buttonSCPView);
            this.Controls.Add(this.buttonSCPEdit);
            this.Controls.Add(this.buttonSCPAdd);
            this.Controls.Add(this.comboAss);
            this.Controls.Add(this.labelAss);
            this.Controls.Add(this.agentClass);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.agentWelcome_label);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "userPortal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.userPortal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label agentWelcome_label;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label agentClass;
        private System.Windows.Forms.Label labelAss;
        private System.Windows.Forms.ComboBox comboAss;
        private System.Windows.Forms.Button buttonSCPAdd;
        private System.Windows.Forms.Button buttonSCPEdit;
        private System.Windows.Forms.Button buttonSCPView;
        private System.Windows.Forms.Button buttonUserView;
        private System.Windows.Forms.Button buttonUserEdit;
        private System.Windows.Forms.ComboBox comboUser;
        private System.Windows.Forms.Label labelUser;
    }
}