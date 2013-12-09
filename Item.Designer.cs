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
            this.itemSCPNumTextBox = new System.Windows.Forms.TextBox();
            this.itemClassTextBox = new System.Windows.Forms.TextBox();
            this.itemDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.itemSCPTextBox = new System.Windows.Forms.RichTextBox();
            this.lblSCP = new System.Windows.Forms.Label();
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
            this.scpNumber.Size = new System.Drawing.Size(71, 25);
            this.scpNumber.TabIndex = 0;
            this.scpNumber.Text = "Item #:";
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
            this.itemDescrip.Location = new System.Drawing.Point(19, 325);
            this.itemDescrip.Name = "itemDescrip";
            this.itemDescrip.Size = new System.Drawing.Size(157, 25);
            this.itemDescrip.TabIndex = 2;
            this.itemDescrip.Text = "Item Description:";
            this.itemDescrip.Click += new System.EventHandler(this.itemDescrip_Click);
            // 
            // itemSCPNumTextBox
            // 
            this.itemSCPNumTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemSCPNumTextBox.Location = new System.Drawing.Point(192, 13);
            this.itemSCPNumTextBox.Name = "itemSCPNumTextBox";
            this.itemSCPNumTextBox.Size = new System.Drawing.Size(402, 20);
            this.itemSCPNumTextBox.TabIndex = 3;
            // 
            // itemClassTextBox
            // 
            this.itemClassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemClassTextBox.Location = new System.Drawing.Point(192, 50);
            this.itemClassTextBox.Name = "itemClassTextBox";
            this.itemClassTextBox.Size = new System.Drawing.Size(402, 20);
            this.itemClassTextBox.TabIndex = 4;
            // 
            // itemDescriptionTextBox
            // 
            this.itemDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemDescriptionTextBox.Location = new System.Drawing.Point(192, 325);
            this.itemDescriptionTextBox.Name = "itemDescriptionTextBox";
            this.itemDescriptionTextBox.Size = new System.Drawing.Size(402, 243);
            this.itemDescriptionTextBox.TabIndex = 5;
            this.itemDescriptionTextBox.Text = "";
            this.itemDescriptionTextBox.TextChanged += new System.EventHandler(this.itemDescriptionTextBox_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCancel.Location = new System.Drawing.Point(406, 585);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(188, 52);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSave.Location = new System.Drawing.Point(192, 585);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(188, 52);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // itemSCPTextBox
            // 
            this.itemSCPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemSCPTextBox.Location = new System.Drawing.Point(192, 76);
            this.itemSCPTextBox.Name = "itemSCPTextBox";
            this.itemSCPTextBox.Size = new System.Drawing.Size(402, 243);
            this.itemSCPTextBox.TabIndex = 9;
            this.itemSCPTextBox.Text = "";
            // 
            // lblSCP
            // 
            this.lblSCP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSCP.AutoSize = true;
            this.lblSCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSCP.Location = new System.Drawing.Point(19, 76);
            this.lblSCP.Name = "lblSCP";
            this.lblSCP.Size = new System.Drawing.Size(102, 25);
            this.lblSCP.TabIndex = 8;
            this.lblSCP.Text = "Item SCP:";
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(719, 865);
            this.Controls.Add(this.itemSCPTextBox);
            this.Controls.Add(this.lblSCP);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.itemDescriptionTextBox);
            this.Controls.Add(this.itemClassTextBox);
            this.Controls.Add(this.itemSCPNumTextBox);
            this.Controls.Add(this.itemDescrip);
            this.Controls.Add(this.itemClass);
            this.Controls.Add(this.scpNumber);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Item";
            this.Load += new System.EventHandler(this.Item_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scpNumber;
        private System.Windows.Forms.Label itemClass;
        private System.Windows.Forms.Label itemDescrip;
        private System.Windows.Forms.TextBox itemSCPNumTextBox;
        private System.Windows.Forms.TextBox itemClassTextBox;
        private System.Windows.Forms.RichTextBox itemDescriptionTextBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RichTextBox itemSCPTextBox;
        private System.Windows.Forms.Label lblSCP;
    }
}