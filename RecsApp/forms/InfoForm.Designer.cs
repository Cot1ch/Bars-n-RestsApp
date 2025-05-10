namespace RecsApp
{
    partial class InfoForm
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
            this.checkBoxStarred = new System.Windows.Forms.CheckBox();
            this.linkLabelToWebSite = new System.Windows.Forms.LinkLabel();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelRating = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLink = new System.Windows.Forms.Label();
            this.textBoxEstDescription = new System.Windows.Forms.TextBox();
            this.textBoxEstAddress = new System.Windows.Forms.TextBox();
            this.textBoxEstRating = new System.Windows.Forms.TextBox();
            this.textBoxEstType = new System.Windows.Forms.TextBox();
            this.textBoxEstName = new System.Windows.Forms.TextBox();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnPrevImage = new System.Windows.Forms.Button();
            this.pictureBoxEstImage = new System.Windows.Forms.PictureBox();
            this.labelFood = new System.Windows.Forms.Label();
            this.labelAverageCheck = new System.Windows.Forms.Label();
            this.textBoxFood = new System.Windows.Forms.TextBox();
            this.textBoxAverageCheck = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstImage)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxStarred
            // 
            this.checkBoxStarred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxStarred.AutoSize = true;
            this.checkBoxStarred.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxStarred.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.checkBoxStarred.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkBoxStarred.Location = new System.Drawing.Point(855, 23);
            this.checkBoxStarred.Name = "checkBoxStarred";
            this.checkBoxStarred.Size = new System.Drawing.Size(108, 22);
            this.checkBoxStarred.TabIndex = 33;
            this.checkBoxStarred.UseVisualStyleBackColor = false;
            this.checkBoxStarred.CheckedChanged += new System.EventHandler(this.checkBoxStarred_CheckedChanged);
            // 
            // linkLabelToWebSite
            // 
            this.linkLabelToWebSite.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.linkLabelToWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelToWebSite.AutoSize = true;
            this.linkLabelToWebSite.Font = new System.Drawing.Font("Verdana", 6.5F, System.Drawing.FontStyle.Bold);
            this.linkLabelToWebSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.linkLabelToWebSite.Location = new System.Drawing.Point(622, 616);
            this.linkLabelToWebSite.Name = "linkLabelToWebSite";
            this.linkLabelToWebSite.Size = new System.Drawing.Size(138, 13);
            this.linkLabelToWebSite.TabIndex = 32;
            this.linkLabelToWebSite.TabStop = true;
            this.linkLabelToWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelToWebSite_LinkClicked);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelAddress.Location = new System.Drawing.Point(497, 145);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(53, 16);
            this.labelAddress.TabIndex = 31;
            this.labelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelRating.Location = new System.Drawing.Point(497, 123);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(63, 16);
            this.labelRating.TabIndex = 30;
            this.labelRating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelType.Location = new System.Drawing.Point(497, 101);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(115, 16);
            this.labelType.TabIndex = 29;
            this.labelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelName.Location = new System.Drawing.Point(497, 56);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(79, 16);
            this.labelName.TabIndex = 28;
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLink
            // 
            this.labelLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLink.AutoSize = true;
            this.labelLink.Font = new System.Drawing.Font("Verdana", 6.5F, System.Drawing.FontStyle.Bold);
            this.labelLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelLink.Location = new System.Drawing.Point(497, 616);
            this.labelLink.Name = "labelLink";
            this.labelLink.Size = new System.Drawing.Size(111, 13);
            this.labelLink.TabIndex = 27;
            // 
            // textBoxEstDescription
            // 
            this.textBoxEstDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxEstDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEstDescription.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.textBoxEstDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.textBoxEstDescription.Location = new System.Drawing.Point(500, 271);
            this.textBoxEstDescription.Multiline = true;
            this.textBoxEstDescription.Name = "textBoxEstDescription";
            this.textBoxEstDescription.ReadOnly = true;
            this.textBoxEstDescription.Size = new System.Drawing.Size(463, 331);
            this.textBoxEstDescription.TabIndex = 26;
            this.textBoxEstDescription.TabStop = false;
            // 
            // textBoxEstAddress
            // 
            this.textBoxEstAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxEstAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEstAddress.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEstAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.textBoxEstAddress.Location = new System.Drawing.Point(500, 164);
            this.textBoxEstAddress.Name = "textBoxEstAddress";
            this.textBoxEstAddress.ReadOnly = true;
            this.textBoxEstAddress.Size = new System.Drawing.Size(463, 16);
            this.textBoxEstAddress.TabIndex = 25;
            this.textBoxEstAddress.TabStop = false;
            // 
            // textBoxEstRating
            // 
            this.textBoxEstRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(147)))), ((int)(((byte)(119)))));
            this.textBoxEstRating.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEstRating.Font = new System.Drawing.Font("Verdana", 10F);
            this.textBoxEstRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(26)))), ((int)(((byte)(29)))));
            this.textBoxEstRating.Location = new System.Drawing.Point(572, 120);
            this.textBoxEstRating.Name = "textBoxEstRating";
            this.textBoxEstRating.ReadOnly = true;
            this.textBoxEstRating.Size = new System.Drawing.Size(74, 21);
            this.textBoxEstRating.TabIndex = 24;
            this.textBoxEstRating.TabStop = false;
            // 
            // textBoxEstType
            // 
            this.textBoxEstType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxEstType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEstType.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEstType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.textBoxEstType.Location = new System.Drawing.Point(641, 101);
            this.textBoxEstType.Name = "textBoxEstType";
            this.textBoxEstType.ReadOnly = true;
            this.textBoxEstType.Size = new System.Drawing.Size(322, 16);
            this.textBoxEstType.TabIndex = 23;
            this.textBoxEstType.TabStop = false;
            // 
            // textBoxEstName
            // 
            this.textBoxEstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxEstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEstName.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.textBoxEstName.Location = new System.Drawing.Point(500, 76);
            this.textBoxEstName.Name = "textBoxEstName";
            this.textBoxEstName.ReadOnly = true;
            this.textBoxEstName.Size = new System.Drawing.Size(463, 16);
            this.textBoxEstName.TabIndex = 22;
            this.textBoxEstName.TabStop = false;
            // 
            // btnNextImage
            // 
            this.btnNextImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btnNextImage.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.btnNextImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.btnNextImage.Location = new System.Drawing.Point(253, 512);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(40, 40);
            this.btnNextImage.TabIndex = 21;
            this.btnNextImage.TabStop = false;
            this.btnNextImage.Text = ">";
            this.btnNextImage.UseVisualStyleBackColor = false;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // btnPrevImage
            // 
            this.btnPrevImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btnPrevImage.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.btnPrevImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.btnPrevImage.Location = new System.Drawing.Point(201, 512);
            this.btnPrevImage.Name = "btnPrevImage";
            this.btnPrevImage.Size = new System.Drawing.Size(40, 40);
            this.btnPrevImage.TabIndex = 20;
            this.btnPrevImage.TabStop = false;
            this.btnPrevImage.Text = "<";
            this.btnPrevImage.UseVisualStyleBackColor = false;
            this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
            // 
            // pictureBoxEstImage
            // 
            this.pictureBoxEstImage.Location = new System.Drawing.Point(22, 56);
            this.pictureBoxEstImage.Name = "pictureBoxEstImage";
            this.pictureBoxEstImage.Size = new System.Drawing.Size(450, 450);
            this.pictureBoxEstImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEstImage.TabIndex = 19;
            this.pictureBoxEstImage.TabStop = false;
            // 
            // labelFood
            // 
            this.labelFood.AutoSize = true;
            this.labelFood.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelFood.Location = new System.Drawing.Point(497, 185);
            this.labelFood.Name = "labelFood";
            this.labelFood.Size = new System.Drawing.Size(52, 16);
            this.labelFood.TabIndex = 34;
            this.labelFood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAverageCheck
            // 
            this.labelAverageCheck.AutoSize = true;
            this.labelAverageCheck.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelAverageCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelAverageCheck.Location = new System.Drawing.Point(497, 226);
            this.labelAverageCheck.Name = "labelAverageCheck";
            this.labelAverageCheck.Size = new System.Drawing.Size(99, 16);
            this.labelAverageCheck.TabIndex = 35;
            this.labelAverageCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxFood
            // 
            this.textBoxFood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxFood.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFood.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.textBoxFood.Location = new System.Drawing.Point(572, 189);
            this.textBoxFood.Multiline = true;
            this.textBoxFood.Name = "textBoxFood";
            this.textBoxFood.ReadOnly = true;
            this.textBoxFood.Size = new System.Drawing.Size(391, 31);
            this.textBoxFood.TabIndex = 36;
            this.textBoxFood.TabStop = false;
            // 
            // textBoxAverageCheck
            // 
            this.textBoxAverageCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(147)))), ((int)(((byte)(119)))));
            this.textBoxAverageCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAverageCheck.Font = new System.Drawing.Font("Verdana", 10F);
            this.textBoxAverageCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(26)))), ((int)(((byte)(29)))));
            this.textBoxAverageCheck.Location = new System.Drawing.Point(625, 222);
            this.textBoxAverageCheck.Name = "textBoxAverageCheck";
            this.textBoxAverageCheck.ReadOnly = true;
            this.textBoxAverageCheck.Size = new System.Drawing.Size(88, 21);
            this.textBoxAverageCheck.TabIndex = 37;
            this.textBoxAverageCheck.TabStop = false;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelDescription.Location = new System.Drawing.Point(497, 252);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(79, 16);
            this.labelDescription.TabIndex = 38;
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHide
            // 
            this.btnHide.FlatAppearance.BorderSize = 0;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnHide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btnHide.Location = new System.Drawing.Point(22, 22);
            this.btnHide.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(90, 28);
            this.btnHide.TabIndex = 39;
            this.btnHide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(147)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxAverageCheck);
            this.Controls.Add(this.textBoxFood);
            this.Controls.Add(this.labelAverageCheck);
            this.Controls.Add(this.labelFood);
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
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "InfoForm";
            this.Text = "Информация о заведении";
            this.Load += new System.EventHandler(this.InfoForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InfoForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxStarred;
        private System.Windows.Forms.LinkLabel linkLabelToWebSite;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLink;
        private System.Windows.Forms.TextBox textBoxEstDescription;
        private System.Windows.Forms.TextBox textBoxEstAddress;
        private System.Windows.Forms.TextBox textBoxEstRating;
        private System.Windows.Forms.TextBox textBoxEstType;
        private System.Windows.Forms.TextBox textBoxEstName;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnPrevImage;
        private System.Windows.Forms.PictureBox pictureBoxEstImage;
        private System.Windows.Forms.Label labelFood;
        private System.Windows.Forms.Label labelAverageCheck;
        private System.Windows.Forms.TextBox textBoxFood;
        private System.Windows.Forms.TextBox textBoxAverageCheck;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button btnHide;
    }
}