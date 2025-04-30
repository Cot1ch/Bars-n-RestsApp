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
            this.btnAccount = new System.Windows.Forms.Button();
            this.dgvEstablishments = new System.Windows.Forms.DataGridView();
            this.labelEstsList = new System.Windows.Forms.Label();
            this.labelSorting = new System.Windows.Forms.Label();
            this.checkBoxFavorite = new System.Windows.Forms.CheckBox();
            this.radioBtnSortByName = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioBtnSortByRating = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstablishments)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccount
            // 
            this.btnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btnAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.btnAccount.Location = new System.Drawing.Point(752, 12);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(118, 36);
            this.btnAccount.TabIndex = 19;
            this.btnAccount.Text = "Аккаунт";
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // dgvEstablishments
            // 
            this.dgvEstablishments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEstablishments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstablishments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.dgvEstablishments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEstablishments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstablishments.Location = new System.Drawing.Point(16, 51);
            this.dgvEstablishments.Name = "dgvEstablishments";
            this.dgvEstablishments.ReadOnly = true;
            this.dgvEstablishments.RowHeadersWidth = 51;
            this.dgvEstablishments.RowTemplate.Height = 24;
            this.dgvEstablishments.Size = new System.Drawing.Size(601, 540);
            this.dgvEstablishments.TabIndex = 20;
            this.dgvEstablishments.DoubleClick += new System.EventHandler(this.dgvEstablishments_DoubleClick);
            // 
            // labelEstsList
            // 
            this.labelEstsList.AutoSize = true;
            this.labelEstsList.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.labelEstsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelEstsList.Location = new System.Drawing.Point(12, 19);
            this.labelEstsList.Name = "labelEstsList";
            this.labelEstsList.Size = new System.Drawing.Size(187, 20);
            this.labelEstsList.TabIndex = 21;
            this.labelEstsList.Text = "Список заведений";
            // 
            // labelSorting
            // 
            this.labelSorting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSorting.AutoSize = true;
            this.labelSorting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.labelSorting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelSorting.Location = new System.Drawing.Point(662, 51);
            this.labelSorting.Name = "labelSorting";
            this.labelSorting.Size = new System.Drawing.Size(198, 18);
            this.labelSorting.TabIndex = 22;
            this.labelSorting.Text = "Сортировка заведений";
            // 
            // checkBoxFavorite
            // 
            this.checkBoxFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFavorite.AutoSize = true;
            this.checkBoxFavorite.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxFavorite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkBoxFavorite.Location = new System.Drawing.Point(665, 569);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(205, 22);
            this.checkBoxFavorite.TabIndex = 23;
            this.checkBoxFavorite.Text = "Отобразить избранное";
            this.checkBoxFavorite.UseVisualStyleBackColor = true;
            // 
            // radioBtnSortByName
            // 
            this.radioBtnSortByName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnSortByName.AutoSize = true;
            this.radioBtnSortByName.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioBtnSortByName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.radioBtnSortByName.Location = new System.Drawing.Point(665, 90);
            this.radioBtnSortByName.Name = "radioBtnSortByName";
            this.radioBtnSortByName.Size = new System.Drawing.Size(130, 22);
            this.radioBtnSortByName.TabIndex = 24;
            this.radioBtnSortByName.TabStop = true;
            this.radioBtnSortByName.Text = "По названию";
            this.radioBtnSortByName.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.radioButton2.Location = new System.Drawing.Point(665, 133);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(89, 22);
            this.radioButton2.TabIndex = 25;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "По типу";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioBtnSortByRating
            // 
            this.radioBtnSortByRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnSortByRating.AutoSize = true;
            this.radioBtnSortByRating.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioBtnSortByRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.radioBtnSortByRating.Location = new System.Drawing.Point(665, 176);
            this.radioBtnSortByRating.Name = "radioBtnSortByRating";
            this.radioBtnSortByRating.Size = new System.Drawing.Size(123, 22);
            this.radioBtnSortByRating.TabIndex = 26;
            this.radioBtnSortByRating.TabStop = true;
            this.radioBtnSortByRating.Text = "По рейтингу";
            this.radioBtnSortByRating.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(147)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(882, 603);
            this.Controls.Add(this.radioBtnSortByRating);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioBtnSortByName);
            this.Controls.Add(this.checkBoxFavorite);
            this.Controls.Add(this.labelSorting);
            this.Controls.Add(this.labelEstsList);
            this.Controls.Add(this.dgvEstablishments);
            this.Controls.Add(this.btnAccount);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstablishments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.DataGridView dgvEstablishments;
        private System.Windows.Forms.Label labelEstsList;
        private System.Windows.Forms.Label labelSorting;
        private System.Windows.Forms.CheckBox checkBoxFavorite;
        private System.Windows.Forms.RadioButton radioBtnSortByName;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioBtnSortByRating;
    }
}