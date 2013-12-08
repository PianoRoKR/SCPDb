namespace SCPDb
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.scpNumber = new System.Windows.Forms.Label();
            this.scpClass = new System.Windows.Forms.Label();
            this.richDescription = new System.Windows.Forms.RichTextBox();
            this.labelDescript = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richAdAss = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richInterview = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // scpNumber
            // 
            this.scpNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scpNumber.AutoSize = true;
            this.scpNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scpNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scpNumber.Location = new System.Drawing.Point(12, 9);
            this.scpNumber.Name = "scpNumber";
            this.scpNumber.Size = new System.Drawing.Size(102, 25);
            this.scpNumber.TabIndex = 1;
            this.scpNumber.Text = "Item SCP:";
            // 
            // scpClass
            // 
            this.scpClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scpClass.AutoSize = true;
            this.scpClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scpClass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scpClass.Location = new System.Drawing.Point(12, 51);
            this.scpClass.Name = "scpClass";
            this.scpClass.Size = new System.Drawing.Size(110, 25);
            this.scpClass.TabIndex = 2;
            this.scpClass.Text = "Item Class:";
            // 
            // richDescription
            // 
            this.richDescription.Location = new System.Drawing.Point(9, 154);
            this.richDescription.Name = "richDescription";
            this.richDescription.ReadOnly = true;
            this.richDescription.Size = new System.Drawing.Size(364, 278);
            this.richDescription.TabIndex = 3;
            this.richDescription.Text = resources.GetString("richDescription.Text");
            // 
            // labelDescript
            // 
            this.labelDescript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescript.AutoSize = true;
            this.labelDescript.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescript.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelDescript.Location = new System.Drawing.Point(135, 118);
            this.labelDescript.Name = "labelDescript";
            this.labelDescript.Size = new System.Drawing.Size(157, 25);
            this.labelDescript.TabIndex = 4;
            this.labelDescript.Text = "Item Description:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(510, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Item Adendum:";
            // 
            // richAdAss
            // 
            this.richAdAss.Location = new System.Drawing.Point(384, 154);
            this.richAdAss.Name = "richAdAss";
            this.richAdAss.ReadOnly = true;
            this.richAdAss.Size = new System.Drawing.Size(364, 278);
            this.richAdAss.TabIndex = 5;
            this.richAdAss.Text = resources.GetString("richAdAss.Text");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(879, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Item Interview:";
            // 
            // richInterview
            // 
            this.richInterview.Location = new System.Drawing.Point(758, 154);
            this.richInterview.Name = "richInterview";
            this.richInterview.ReadOnly = true;
            this.richInterview.Size = new System.Drawing.Size(364, 278);
            this.richInterview.TabIndex = 7;
            this.richInterview.Text = resources.GetString("richInterview.Text");
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1142, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richInterview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richAdAss);
            this.Controls.Add(this.labelDescript);
            this.Controls.Add(this.richDescription);
            this.Controls.Add(this.scpClass);
            this.Controls.Add(this.scpNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "View";
            this.Text = "SCP View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scpNumber;
        private System.Windows.Forms.Label scpClass;
        private System.Windows.Forms.RichTextBox richDescription;
        private System.Windows.Forms.Label labelDescript;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richAdAss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richInterview;
    }
}