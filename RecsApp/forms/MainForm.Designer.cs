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
            this.radioBtnSortByType = new System.Windows.Forms.RadioButton();
            this.radioBtnSortByRating = new System.Windows.Forms.RadioButton();
            this.dgvMayLike = new System.Windows.Forms.DataGridView();
            this.labelMayLike = new System.Windows.Forms.Label();
            this.radioBtnSortByVisits = new System.Windows.Forms.RadioButton();
            this.btnChangeFile = new System.Windows.Forms.Button();
            this.openFDEstablishmentsFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstablishments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMayLike)).BeginInit();
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
            this.btnAccount.Location = new System.Drawing.Point(942, 12);
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
            this.dgvEstablishments.Location = new System.Drawing.Point(27, 54);
            this.dgvEstablishments.Name = "dgvEstablishments";
            this.dgvEstablishments.ReadOnly = true;
            this.dgvEstablishments.RowHeadersWidth = 51;
            this.dgvEstablishments.RowTemplate.Height = 24;
            this.dgvEstablishments.Size = new System.Drawing.Size(593, 687);
            this.dgvEstablishments.TabIndex = 20;
            this.dgvEstablishments.DoubleClick += new System.EventHandler(this.dgvEstablishments_DoubleClick);
            // 
            // labelEstsList
            // 
            this.labelEstsList.AutoSize = true;
            this.labelEstsList.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.labelEstsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelEstsList.Location = new System.Drawing.Point(23, 18);
            this.labelEstsList.Name = "labelEstsList";
            this.labelEstsList.Size = new System.Drawing.Size(214, 23);
            this.labelEstsList.TabIndex = 21;
            this.labelEstsList.Text = "Список заведений";
            // 
            // labelSorting
            // 
            this.labelSorting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSorting.AutoSize = true;
            this.labelSorting.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.labelSorting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelSorting.Location = new System.Drawing.Point(637, 54);
            this.labelSorting.Name = "labelSorting";
            this.labelSorting.Size = new System.Drawing.Size(264, 23);
            this.labelSorting.TabIndex = 22;
            this.labelSorting.Text = "Сортировка заведений";
            // 
            // checkBoxFavorite
            // 
            this.checkBoxFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFavorite.AutoSize = true;
            this.checkBoxFavorite.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxFavorite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkBoxFavorite.Location = new System.Drawing.Point(855, 719);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(205, 22);
            this.checkBoxFavorite.TabIndex = 23;
            this.checkBoxFavorite.Text = "Отобразить избранное";
            this.checkBoxFavorite.UseVisualStyleBackColor = true;
            this.checkBoxFavorite.CheckedChanged += new System.EventHandler(this.checkBoxFavorite_CheckedChanged);
            // 
            // radioBtnSortByName
            // 
            this.radioBtnSortByName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnSortByName.AutoSize = true;
            this.radioBtnSortByName.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioBtnSortByName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.radioBtnSortByName.Location = new System.Drawing.Point(654, 118);
            this.radioBtnSortByName.Name = "radioBtnSortByName";
            this.radioBtnSortByName.Size = new System.Drawing.Size(130, 22);
            this.radioBtnSortByName.TabIndex = 24;
            this.radioBtnSortByName.TabStop = true;
            this.radioBtnSortByName.Text = "По названию";
            this.radioBtnSortByName.UseVisualStyleBackColor = true;
            this.radioBtnSortByName.CheckedChanged += new System.EventHandler(this.radioBtnSortByName_CheckedChanged);
            // 
            // radioBtnSortByType
            // 
            this.radioBtnSortByType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnSortByType.AutoSize = true;
            this.radioBtnSortByType.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioBtnSortByType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.radioBtnSortByType.Location = new System.Drawing.Point(650, 174);
            this.radioBtnSortByType.Name = "radioBtnSortByType";
            this.radioBtnSortByType.Size = new System.Drawing.Size(89, 22);
            this.radioBtnSortByType.TabIndex = 25;
            this.radioBtnSortByType.TabStop = true;
            this.radioBtnSortByType.Text = "По типу";
            this.radioBtnSortByType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnSortByType.UseVisualStyleBackColor = false;
            this.radioBtnSortByType.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioBtnSortByRating
            // 
            this.radioBtnSortByRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnSortByRating.AutoSize = true;
            this.radioBtnSortByRating.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioBtnSortByRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.radioBtnSortByRating.Location = new System.Drawing.Point(656, 146);
            this.radioBtnSortByRating.Name = "radioBtnSortByRating";
            this.radioBtnSortByRating.Size = new System.Drawing.Size(123, 22);
            this.radioBtnSortByRating.TabIndex = 26;
            this.radioBtnSortByRating.TabStop = true;
            this.radioBtnSortByRating.Text = "По рейтингу";
            this.radioBtnSortByRating.UseVisualStyleBackColor = true;
            this.radioBtnSortByRating.CheckedChanged += new System.EventHandler(this.radioBtnSortByRating_CheckedChanged);
            // 
            // dgvMayLike
            // 
            this.dgvMayLike.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMayLike.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMayLike.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.dgvMayLike.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMayLike.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMayLike.Location = new System.Drawing.Point(641, 254);
            this.dgvMayLike.Name = "dgvMayLike";
            this.dgvMayLike.ReadOnly = true;
            this.dgvMayLike.RowHeadersWidth = 51;
            this.dgvMayLike.RowTemplate.Height = 24;
            this.dgvMayLike.Size = new System.Drawing.Size(419, 444);
            this.dgvMayLike.TabIndex = 27;
            this.dgvMayLike.DoubleClick += new System.EventHandler(this.dgvMayLike_DoubleClick);
            // 
            // labelMayLike
            // 
            this.labelMayLike.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMayLike.AutoSize = true;
            this.labelMayLike.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.labelMayLike.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelMayLike.Location = new System.Drawing.Point(637, 219);
            this.labelMayLike.Name = "labelMayLike";
            this.labelMayLike.Size = new System.Drawing.Size(205, 20);
            this.labelMayLike.TabIndex = 28;
            this.labelMayLike.Text = "Может понравиться";
            // 
            // radioBtnSortByVisits
            // 
            this.radioBtnSortByVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnSortByVisits.AutoSize = true;
            this.radioBtnSortByVisits.Font = new System.Drawing.Font("Verdana", 9F);
            this.radioBtnSortByVisits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.radioBtnSortByVisits.Location = new System.Drawing.Point(656, 90);
            this.radioBtnSortByVisits.Name = "radioBtnSortByVisits";
            this.radioBtnSortByVisits.Size = new System.Drawing.Size(162, 22);
            this.radioBtnSortByVisits.TabIndex = 29;
            this.radioBtnSortByVisits.TabStop = true;
            this.radioBtnSortByVisits.Text = "По популярности";
            this.radioBtnSortByVisits.UseVisualStyleBackColor = true;
            this.radioBtnSortByVisits.CheckedChanged += new System.EventHandler(this.radioBtnSortByVisits_CheckedChanged);
            // 
            // btnChangeFile
            // 
            this.btnChangeFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btnChangeFile.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnChangeFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.btnChangeFile.Location = new System.Drawing.Point(331, 12);
            this.btnChangeFile.Name = "btnChangeFile";
            this.btnChangeFile.Size = new System.Drawing.Size(289, 36);
            this.btnChangeFile.TabIndex = 30;
            this.btnChangeFile.Text = "Изменить файл заведений";
            this.btnChangeFile.UseVisualStyleBackColor = false;
            this.btnChangeFile.Visible = false;
            this.btnChangeFile.Click += new System.EventHandler(this.buttonAdmin_Click);
            // 
            // openFDEstablishmentsFile
            // 
            this.openFDEstablishmentsFile.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(147)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.btnChangeFile);
            this.Controls.Add(this.radioBtnSortByVisits);
            this.Controls.Add(this.labelMayLike);
            this.Controls.Add(this.dgvMayLike);
            this.Controls.Add(this.radioBtnSortByRating);
            this.Controls.Add(this.radioBtnSortByType);
            this.Controls.Add(this.radioBtnSortByName);
            this.Controls.Add(this.checkBoxFavorite);
            this.Controls.Add(this.labelSorting);
            this.Controls.Add(this.labelEstsList);
            this.Controls.Add(this.dgvEstablishments);
            this.Controls.Add(this.btnAccount);
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.Name = "MainForm";
            this.Text = "Главная форма";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstablishments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMayLike)).EndInit();
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
        private System.Windows.Forms.RadioButton radioBtnSortByType;
        private System.Windows.Forms.RadioButton radioBtnSortByRating;
        private System.Windows.Forms.DataGridView dgvMayLike;
        private System.Windows.Forms.Label labelMayLike;
        private System.Windows.Forms.RadioButton radioBtnSortByVisits;
        private System.Windows.Forms.Button btnChangeFile;
        private System.Windows.Forms.OpenFileDialog openFDEstablishmentsFile;
    }
}