namespace LibraryItems
{
    partial class BookEdit
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
            this.slctBookLbl = new System.Windows.Forms.Label();
            this.slctBookComBox = new System.Windows.Forms.ComboBox();
            this.bookEditButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // slctBookLbl
            // 
            this.slctBookLbl.AutoSize = true;
            this.slctBookLbl.Location = new System.Drawing.Point(81, 9);
            this.slctBookLbl.Name = "slctBookLbl";
            this.slctBookLbl.Size = new System.Drawing.Size(65, 13);
            this.slctBookLbl.TabIndex = 0;
            this.slctBookLbl.Text = "Select Book";
            // 
            // slctBookComBox
            // 
            this.slctBookComBox.FormattingEnabled = true;
            this.slctBookComBox.Location = new System.Drawing.Point(59, 25);
            this.slctBookComBox.Name = "slctBookComBox";
            this.slctBookComBox.Size = new System.Drawing.Size(121, 21);
            this.slctBookComBox.TabIndex = 1;
            // 
            // bookEditButton
            // 
            this.bookEditButton.Location = new System.Drawing.Point(84, 52);
            this.bookEditButton.Name = "bookEditButton";
            this.bookEditButton.Size = new System.Drawing.Size(75, 23);
            this.bookEditButton.TabIndex = 2;
            this.bookEditButton.Text = "Edit";
            this.bookEditButton.UseVisualStyleBackColor = true;
            this.bookEditButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BookEdit
            // 
            this.AcceptButton = this.bookEditButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 115);
            this.Controls.Add(this.bookEditButton);
            this.Controls.Add(this.slctBookComBox);
            this.Controls.Add(this.slctBookLbl);
            this.Name = "BookEdit";
            this.Text = "Edit Book";
            this.Load += new System.EventHandler(this.BookEdit_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.BookEdit_Validating);
            this.Validated += new System.EventHandler(this.BookEdit_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label slctBookLbl;
        private System.Windows.Forms.ComboBox slctBookComBox;
        private System.Windows.Forms.Button bookEditButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}