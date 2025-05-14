namespace RecsApp
{
    partial class AccountForm
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.checkedListBoxCategory = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxType = new System.Windows.Forms.CheckedListBox();
            this.buttonAccExit = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.labelAccount = new System.Windows.Forms.Label();
            this.checkedListBoxAverage = new System.Windows.Forms.CheckedListBox();
            this.labelFood = new System.Windows.Forms.Label();
            this.labelAverage = new System.Windows.Forms.Label();
            this.checkBoxRating = new System.Windows.Forms.CheckBox();
            this.checkedListBoxFood = new System.Windows.Forms.CheckedListBox();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelName.Location = new System.Drawing.Point(37, 80);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(48, 22);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Имя";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelLogin.Location = new System.Drawing.Point(37, 140);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(65, 22);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Логин";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelCategory.Location = new System.Drawing.Point(37, 321);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(106, 22);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Категория";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelType.Location = new System.Drawing.Point(37, 200);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(44, 22);
            this.labelType.TabIndex = 3;
            this.labelType.Text = "Тип";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(40, 105);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(287, 22);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLogin.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin.Location = new System.Drawing.Point(40, 165);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.ReadOnly = true;
            this.textBoxLogin.Size = new System.Drawing.Size(287, 22);
            this.textBoxLogin.TabIndex = 6;
            // 
            // checkedListBoxCategory
            // 
            this.checkedListBoxCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkedListBoxCategory.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.checkedListBoxCategory.FormattingEnabled = true;
            this.checkedListBoxCategory.Location = new System.Drawing.Point(40, 346);
            this.checkedListBoxCategory.Name = "checkedListBoxCategory";
            this.checkedListBoxCategory.Size = new System.Drawing.Size(485, 220);
            this.checkedListBoxCategory.Sorted = true;
            this.checkedListBoxCategory.TabIndex = 7;
            // 
            // checkedListBoxType
            // 
            this.checkedListBoxType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkedListBoxType.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.checkedListBoxType.FormattingEnabled = true;
            this.checkedListBoxType.Location = new System.Drawing.Point(40, 225);
            this.checkedListBoxType.Name = "checkedListBoxType";
            this.checkedListBoxType.Size = new System.Drawing.Size(485, 76);
            this.checkedListBoxType.TabIndex = 8;
            // 
            // buttonAccExit
            // 
            this.buttonAccExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.buttonAccExit.Font = new System.Drawing.Font("Verdana", 10F);
            this.buttonAccExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.buttonAccExit.Location = new System.Drawing.Point(785, 35);
            this.buttonAccExit.Name = "buttonAccExit";
            this.buttonAccExit.Size = new System.Drawing.Size(255, 30);
            this.buttonAccExit.TabIndex = 9;
            this.buttonAccExit.Text = "Выйти из аккаунта";
            this.buttonAccExit.UseVisualStyleBackColor = false;
            this.buttonAccExit.Click += new System.EventHandler(this.buttonAccExit_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btnSaveChanges.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnSaveChanges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.btnSaveChanges.Location = new System.Drawing.Point(785, 692);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(255, 30);
            this.btnSaveChanges.TabIndex = 10;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.labelAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelAccount.Location = new System.Drawing.Point(35, 40);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(227, 26);
            this.labelAccount.TabIndex = 11;
            this.labelAccount.Text = "Личный кабинет";
            // 
            // checkedListBoxAverage
            // 
            this.checkedListBoxAverage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkedListBoxAverage.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxAverage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.checkedListBoxAverage.FormattingEnabled = true;
            this.checkedListBoxAverage.Location = new System.Drawing.Point(557, 225);
            this.checkedListBoxAverage.Name = "checkedListBoxAverage";
            this.checkedListBoxAverage.Size = new System.Drawing.Size(485, 76);
            this.checkedListBoxAverage.Sorted = true;
            this.checkedListBoxAverage.TabIndex = 12;
            // 
            // labelFood
            // 
            this.labelFood.AutoSize = true;
            this.labelFood.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelFood.Location = new System.Drawing.Point(554, 321);
            this.labelFood.Name = "labelFood";
            this.labelFood.Size = new System.Drawing.Size(66, 22);
            this.labelFood.TabIndex = 14;
            this.labelFood.Text = "Кухня";
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAverage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelAverage.Location = new System.Drawing.Point(554, 200);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(130, 22);
            this.labelAverage.TabIndex = 15;
            this.labelAverage.Text = "Средний чек";
            // 
            // checkBoxRating
            // 
            this.checkBoxRating.AutoSize = true;
            this.checkBoxRating.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkBoxRating.Location = new System.Drawing.Point(40, 584);
            this.checkBoxRating.Name = "checkBoxRating";
            this.checkBoxRating.Size = new System.Drawing.Size(287, 26);
            this.checkBoxRating.TabIndex = 16;
            this.checkBoxRating.Text = "Заведения с рейтингом 5.0";
            this.checkBoxRating.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxFood
            // 
            this.checkedListBoxFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkedListBoxFood.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkedListBoxFood.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.checkedListBoxFood.FormattingEnabled = true;
            this.checkedListBoxFood.Location = new System.Drawing.Point(557, 346);
            this.checkedListBoxFood.Name = "checkedListBoxFood";
            this.checkedListBoxFood.Size = new System.Drawing.Size(483, 220);
            this.checkedListBoxFood.Sorted = true;
            this.checkedListBoxFood.TabIndex = 13;
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(147)))), ((int)(((byte)(119)))));
            this.btnSaveReport.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnSaveReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.btnSaveReport.Location = new System.Drawing.Point(40, 692);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(178, 30);
            this.btnSaveReport.TabIndex = 17;
            this.btnSaveReport.Text = "Скачать отчет";
            this.btnSaveReport.UseVisualStyleBackColor = false;
            this.btnSaveReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(147)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.btnSaveReport);
            this.Controls.Add(this.checkBoxRating);
            this.Controls.Add(this.labelAverage);
            this.Controls.Add(this.labelFood);
            this.Controls.Add(this.checkedListBoxFood);
            this.Controls.Add(this.checkedListBoxAverage);
            this.Controls.Add(this.labelAccount);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.buttonAccExit);
            this.Controls.Add(this.checkedListBoxType);
            this.Controls.Add(this.checkedListBoxCategory);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 800);
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.Name = "AccountForm";
            this.Text = "Личный кабинет";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategory;
        private System.Windows.Forms.CheckedListBox checkedListBoxType;
        private System.Windows.Forms.Button buttonAccExit;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.CheckedListBox checkedListBoxAverage;
        private System.Windows.Forms.Label labelFood;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.CheckBox checkBoxRating;
        private System.Windows.Forms.CheckedListBox checkedListBoxFood;
        private System.Windows.Forms.Button btnSaveReport;
    }
}