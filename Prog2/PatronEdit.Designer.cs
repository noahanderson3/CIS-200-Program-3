namespace LibraryItems
{
    partial class PatronEdit
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
            this.components = new System.ComponentModel.Container();
            this.slctPatronCmBox = new System.Windows.Forms.ComboBox();
            this.slctPatronLbl = new System.Windows.Forms.Label();
            this.editPatronButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // slctPatronCmBox
            // 
            this.slctPatronCmBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.slctPatronCmBox.FormattingEnabled = true;
            this.slctPatronCmBox.Location = new System.Drawing.Point(42, 25);
            this.slctPatronCmBox.Name = "slctPatronCmBox";
            this.slctPatronCmBox.Size = new System.Drawing.Size(121, 21);
            this.slctPatronCmBox.TabIndex = 0;
            // 
            // slctPatronLbl
            // 
            this.slctPatronLbl.AutoSize = true;
            this.slctPatronLbl.Location = new System.Drawing.Point(67, 9);
            this.slctPatronLbl.Name = "slctPatronLbl";
            this.slctPatronLbl.Size = new System.Drawing.Size(71, 13);
            this.slctPatronLbl.TabIndex = 1;
            this.slctPatronLbl.Text = "Select Patron";
            // 
            // editPatronButton
            // 
            this.editPatronButton.Location = new System.Drawing.Point(63, 52);
            this.editPatronButton.Name = "editPatronButton";
            this.editPatronButton.Size = new System.Drawing.Size(75, 23);
            this.editPatronButton.TabIndex = 2;
            this.editPatronButton.Text = "Edit";
            this.editPatronButton.UseVisualStyleBackColor = true;
            this.editPatronButton.Click += new System.EventHandler(this.EditPatronButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PatronEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 96);
            this.Controls.Add(this.editPatronButton);
            this.Controls.Add(this.slctPatronLbl);
            this.Controls.Add(this.slctPatronCmBox);
            this.Name = "PatronEdit";
            this.Text = "Select Patron";
            this.Load += new System.EventHandler(this.PatronEdit_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.PatronEdit_Validating);
            this.Validated += new System.EventHandler(this.PatronEdit_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox slctPatronCmBox;
        private System.Windows.Forms.Label slctPatronLbl;
        private System.Windows.Forms.Button editPatronButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}