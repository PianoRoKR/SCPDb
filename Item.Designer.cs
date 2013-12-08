namespace SCPDb
{
    partial class Item
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
            this.scpNumber = new System.Windows.Forms.Label();
            this.itemClass = new System.Windows.Forms.Label();
            this.itemDescrip = new System.Windows.Forms.Label();
            this.itemSCPTextBox = new System.Windows.Forms.TextBox();
            this.itemClassTextBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scpNumber
            // 
            this.scpNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scpNumber.AutoSize = true;
            this.scpNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scpNumber.Location = new System.Drawing.Point(19, 13);
            this.scpNumber.Name = "scpNumber";
            this.scpNumber.Size = new System.Drawing.Size(102, 25);
            this.scpNumber.TabIndex = 0;
            this.scpNumber.Text = "Item SCP:";
            // 
            // itemClass
            // 
            this.itemClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemClass.AutoSize = true;
            this.itemClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemClass.Location = new System.Drawing.Point(19, 45);
            this.itemClass.Name = "itemClass";
            this.itemClass.Size = new System.Drawing.Size(115, 25);
            this.itemClass.TabIndex = 1;
            this.itemClass.Text = "Item Class: ";
            this.itemClass.Click += new System.EventHandler(this.itemClass_Click);
            // 
            // itemDescrip
            // 
            this.itemDescrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemDescrip.AutoSize = true;
            this.itemDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDescrip.Location = new System.Drawing.Point(19, 78);
            this.itemDescrip.Name = "itemDescrip";
            this.itemDescrip.Size = new System.Drawing.Size(157, 25);
            this.itemDescrip.TabIndex = 2;
            this.itemDescrip.Text = "Item Description:";
            // 
            // itemSCPTextBox
            // 
            this.itemSCPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemSCPTextBox.Location = new System.Drawing.Point(192, 19);
            this.itemSCPTextBox.Name = "itemSCPTextBox";
            this.itemSCPTextBox.Size = new System.Drawing.Size(402, 20);
            this.itemSCPTextBox.TabIndex = 3;
            // 
            // itemClassTextBox
            // 
            this.itemClassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemClassTextBox.Location = new System.Drawing.Point(192, 51);
            this.itemClassTextBox.Name = "itemClassTextBox";
            this.itemClassTextBox.Size = new System.Drawing.Size(402, 20);
            this.itemClassTextBox.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(192, 84);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(402, 243);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // buttonSave
            // 
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSave.Location = new System.Drawing.Point(192, 338);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(208, 52);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCancel.Location = new System.Drawing.Point(386, 338);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(208, 52);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(719, 448);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.itemClassTextBox);
            this.Controls.Add(this.itemSCPTextBox);
            this.Controls.Add(this.itemDescrip);
            this.Controls.Add(this.itemClass);
            this.Controls.Add(this.scpNumber);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scpNumber;
        private System.Windows.Forms.Label itemClass;
        private System.Windows.Forms.Label itemDescrip;
        private System.Windows.Forms.TextBox itemSCPTextBox;
        private System.Windows.Forms.TextBox itemClassTextBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}