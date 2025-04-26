namespace RecsApp
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
            this.listBoxEstablishments = new System.Windows.Forms.ListBox();
            this.pictureBoxEstImage = new System.Windows.Forms.PictureBox();
            this.btnPrevImage = new System.Windows.Forms.Button();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.textBoxEstName = new System.Windows.Forms.TextBox();
            this.textBoxEstType = new System.Windows.Forms.TextBox();
            this.textBoxEstRating = new System.Windows.Forms.TextBox();
            this.textBoxEstAddress = new System.Windows.Forms.TextBox();
            this.textBoxEstDescription = new System.Windows.Forms.TextBox();
            this.labelLink = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelRating = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.linkLabelToWebSite = new System.Windows.Forms.LinkLabel();
            this.checkBoxStarred = new System.Windows.Forms.CheckBox();
            this.btnAccount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstImage)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxEstablishments
            // 
            this.listBoxEstablishments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEstablishments.FormattingEnabled = true;
            this.listBoxEstablishments.ItemHeight = 16;
            this.listBoxEstablishments.Location = new System.Drawing.Point(12, 27);
            this.listBoxEstablishments.Name = "listBoxEstablishments";
            this.listBoxEstablishments.Size = new System.Drawing.Size(270, 548);
            this.listBoxEstablishments.Sorted = true;
            this.listBoxEstablishments.TabIndex = 0;
            this.listBoxEstablishments.SelectedIndexChanged += new System.EventHandler(this.listBoxEstablishments_SelectedIndexChanged);
            // 
            // pictureBoxEstImage
            // 
            this.pictureBoxEstImage.Location = new System.Drawing.Point(290, 27);
            this.pictureBoxEstImage.Name = "pictureBoxEstImage";
            this.pictureBoxEstImage.Size = new System.Drawing.Size(296, 305);
            this.pictureBoxEstImage.TabIndex = 1;
            this.pictureBoxEstImage.TabStop = false;
            // 
            // btnPrevImage
            // 
            this.btnPrevImage.Location = new System.Drawing.Point(397, 338);
            this.btnPrevImage.Name = "btnPrevImage";
            this.btnPrevImage.Size = new System.Drawing.Size(40, 40);
            this.btnPrevImage.TabIndex = 2;
            this.btnPrevImage.Text = "<";
            this.btnPrevImage.UseVisualStyleBackColor = true;
            this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
            // 
            // btnNextImage
            // 
            this.btnNextImage.Location = new System.Drawing.Point(443, 338);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(40, 40);
            this.btnNextImage.TabIndex = 3;
            this.btnNextImage.Text = ">";
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // textBoxEstName
            // 
            this.textBoxEstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxEstName.Location = new System.Drawing.Point(671, 144);
            this.textBoxEstName.Name = "textBoxEstName";
            this.textBoxEstName.ReadOnly = true;
            this.textBoxEstName.Size = new System.Drawing.Size(199, 22);
            this.textBoxEstName.TabIndex = 4;
            // 
            // textBoxEstType
            // 
            this.textBoxEstType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstType.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxEstType.Location = new System.Drawing.Point(671, 172);
            this.textBoxEstType.Name = "textBoxEstType";
            this.textBoxEstType.ReadOnly = true;
            this.textBoxEstType.Size = new System.Drawing.Size(199, 22);
            this.textBoxEstType.TabIndex = 5;
            // 
            // textBoxEstRating
            // 
            this.textBoxEstRating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstRating.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxEstRating.Location = new System.Drawing.Point(671, 200);
            this.textBoxEstRating.Name = "textBoxEstRating";
            this.textBoxEstRating.ReadOnly = true;
            this.textBoxEstRating.Size = new System.Drawing.Size(199, 22);
            this.textBoxEstRating.TabIndex = 6;
            // 
            // textBoxEstAddress
            // 
            this.textBoxEstAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstAddress.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxEstAddress.Location = new System.Drawing.Point(671, 228);
            this.textBoxEstAddress.Name = "textBoxEstAddress";
            this.textBoxEstAddress.ReadOnly = true;
            this.textBoxEstAddress.Size = new System.Drawing.Size(199, 22);
            this.textBoxEstAddress.TabIndex = 7;
            // 
            // textBoxEstDescription
            // 
            this.textBoxEstDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstDescription.Location = new System.Drawing.Point(291, 384);
            this.textBoxEstDescription.Multiline = true;
            this.textBoxEstDescription.Name = "textBoxEstDescription";
            this.textBoxEstDescription.Size = new System.Drawing.Size(580, 146);
            this.textBoxEstDescription.TabIndex = 8;
            // 
            // labelLink
            // 
            this.labelLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLink.AutoSize = true;
            this.labelLink.Location = new System.Drawing.Point(288, 560);
            this.labelLink.Name = "labelLink";
            this.labelLink.Size = new System.Drawing.Size(26, 16);
            this.labelLink.TabIndex = 11;
            this.labelLink.Text = "--->";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(592, 150);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(73, 16);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Название";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(592, 178);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(32, 16);
            this.labelType.TabIndex = 13;
            this.labelType.Text = "Тип";
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Location = new System.Drawing.Point(592, 206);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(56, 16);
            this.labelRating.TabIndex = 14;
            this.labelRating.Text = "Оценка";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(592, 234);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(47, 16);
            this.labelAddress.TabIndex = 15;
            this.labelAddress.Text = "Адрес";
            // 
            // linkLabelToWebSite
            // 
            this.linkLabelToWebSite.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.linkLabelToWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelToWebSite.AutoSize = true;
            this.linkLabelToWebSite.LinkColor = System.Drawing.Color.Black;
            this.linkLabelToWebSite.Location = new System.Drawing.Point(320, 560);
            this.linkLabelToWebSite.Name = "linkLabelToWebSite";
            this.linkLabelToWebSite.Size = new System.Drawing.Size(221, 16);
            this.linkLabelToWebSite.TabIndex = 17;
            this.linkLabelToWebSite.TabStop = true;
            this.linkLabelToWebSite.Text = "тут могла быть ссылка, но ее нет";
            // 
            // checkBoxStarred
            // 
            this.checkBoxStarred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxStarred.AutoSize = true;
            this.checkBoxStarred.Location = new System.Drawing.Point(768, 89);
            this.checkBoxStarred.Name = "checkBoxStarred";
            this.checkBoxStarred.Size = new System.Drawing.Size(103, 20);
            this.checkBoxStarred.TabIndex = 18;
            this.checkBoxStarred.Text = "Избранное";
            this.checkBoxStarred.UseVisualStyleBackColor = true;
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(768, 27);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(102, 23);
            this.btnAccount.TabIndex = 19;
            this.btnAccount.Text = "Аккаунт";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(882, 603);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.checkBoxStarred);
            this.Controls.Add(this.linkLabelToWebSite);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelRating);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelLink);
            this.Controls.Add(this.textBoxEstDescription);
            this.Controls.Add(this.textBoxEstAddress);
            this.Controls.Add(this.textBoxEstRating);
            this.Controls.Add(this.textBoxEstType);
            this.Controls.Add(this.textBoxEstName);
            this.Controls.Add(this.btnNextImage);
            this.Controls.Add(this.btnPrevImage);
            this.Controls.Add(this.pictureBoxEstImage);
            this.Controls.Add(this.listBoxEstablishments);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEstablishments;
        private System.Windows.Forms.PictureBox pictureBoxEstImage;
        private System.Windows.Forms.Button btnPrevImage;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.TextBox textBoxEstName;
        private System.Windows.Forms.TextBox textBoxEstType;
        private System.Windows.Forms.TextBox textBoxEstRating;
        private System.Windows.Forms.TextBox textBoxEstAddress;
        private System.Windows.Forms.TextBox textBoxEstDescription;
        private System.Windows.Forms.Label labelLink;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.LinkLabel linkLabelToWebSite;
        private System.Windows.Forms.CheckBox checkBoxStarred;
        private System.Windows.Forms.Button btnAccount;
    }
}