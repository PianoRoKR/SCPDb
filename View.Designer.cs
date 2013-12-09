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
            this.lblNum = new System.Windows.Forms.Label();
            this.lblScpClass = new System.Windows.Forms.Label();
            this.richDescription = new System.Windows.Forms.RichTextBox();
            this.labelDescript = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richAdAss = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richInterview = new System.Windows.Forms.RichTextBox();
            this.lblSCPNum = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblSCP = new System.Windows.Forms.Label();
            this.itemSCPTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblNum
            // 
            this.lblNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNum.Location = new System.Drawing.Point(12, 9);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(71, 25);
            this.lblNum.TabIndex = 1;
            this.lblNum.Text = "Item #:";
            // 
            // lblScpClass
            // 
            this.lblScpClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScpClass.AutoSize = true;
            this.lblScpClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScpClass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblScpClass.Location = new System.Drawing.Point(12, 51);
            this.lblScpClass.Name = "lblScpClass";
            this.lblScpClass.Size = new System.Drawing.Size(110, 25);
            this.lblScpClass.TabIndex = 2;
            this.lblScpClass.Text = "Item Class:";
            // 
            // richDescription
            // 
            this.richDescription.Location = new System.Drawing.Point(384, 154);
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
            this.labelDescript.Location = new System.Drawing.Point(510, 118);
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
            this.label2.Location = new System.Drawing.Point(510, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Item Adendum:";
            // 
            // richAdAss
            // 
            this.richAdAss.Location = new System.Drawing.Point(384, 471);
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
            this.label3.Location = new System.Drawing.Point(135, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Item Interview:";
            // 
            // richInterview
            // 
            this.richInterview.Location = new System.Drawing.Point(14, 471);
            this.richInterview.Name = "richInterview";
            this.richInterview.ReadOnly = true;
            this.richInterview.Size = new System.Drawing.Size(364, 278);
            this.richInterview.TabIndex = 7;
            this.richInterview.Text = resources.GetString("richInterview.Text");
            // 
            // lblSCPNum
            // 
            this.lblSCPNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSCPNum.AutoSize = true;
            this.lblSCPNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSCPNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSCPNum.Location = new System.Drawing.Point(135, 9);
            this.lblSCPNum.Name = "lblSCPNum";
            this.lblSCPNum.Size = new System.Drawing.Size(102, 25);
            this.lblSCPNum.TabIndex = 9;
            this.lblSCPNum.Text = "Item SCP:";
            // 
            // lblClass
            // 
            this.lblClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblClass.Location = new System.Drawing.Point(135, 51);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(102, 25);
            this.lblClass.TabIndex = 10;
            this.lblClass.Text = "Item SCP:";
            // 
            // lblSCP
            // 
            this.lblSCP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSCP.AutoSize = true;
            this.lblSCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSCP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSCP.Location = new System.Drawing.Point(135, 118);
            this.lblSCP.Name = "lblSCP";
            this.lblSCP.Size = new System.Drawing.Size(102, 25);
            this.lblSCP.TabIndex = 12;
            this.lblSCP.Text = "Item SCP:";
            // 
            // itemSCPTextBox
            // 
            this.itemSCPTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.itemSCPTextBox.Location = new System.Drawing.Point(14, 154);
            this.itemSCPTextBox.Name = "itemSCPTextBox";
            this.itemSCPTextBox.ReadOnly = true;
            this.itemSCPTextBox.Size = new System.Drawing.Size(364, 278);
            this.itemSCPTextBox.TabIndex = 11;
            this.itemSCPTextBox.Text = resources.GetString("itemSCPTextBox.Text");
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(766, 821);
            this.Controls.Add(this.lblSCP);
            this.Controls.Add(this.itemSCPTextBox);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblSCPNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richInterview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richAdAss);
            this.Controls.Add(this.labelDescript);
            this.Controls.Add(this.richDescription);
            this.Controls.Add(this.lblScpClass);
            this.Controls.Add(this.lblNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "View";
            this.Text = "SCP View";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblScpClass;
        private System.Windows.Forms.RichTextBox richDescription;
        private System.Windows.Forms.Label labelDescript;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richAdAss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richInterview;
        private System.Windows.Forms.Label lblSCPNum;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblSCP;
        private System.Windows.Forms.RichTextBox itemSCPTextBox;
    }
}