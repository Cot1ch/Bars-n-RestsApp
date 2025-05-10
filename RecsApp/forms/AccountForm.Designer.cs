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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkedListBoxCategory = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxType = new System.Windows.Forms.CheckedListBox();
            this.buttonAccExit = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxAverage = new System.Windows.Forms.CheckedListBox();
            this.labelFood = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxRating = new System.Windows.Forms.CheckBox();
            this.checkedListBoxFood = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Verdana", 9F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelName.Location = new System.Drawing.Point(37, 72);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 18);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Имя";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Verdana", 9F);
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelLogin.Location = new System.Drawing.Point(37, 132);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(54, 18);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Логин";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Verdana", 9F);
            this.labelCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelCategory.Location = new System.Drawing.Point(37, 313);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(87, 18);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Категория";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Verdana", 9F);
            this.labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelType.Location = new System.Drawing.Point(37, 192);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(35, 18);
            this.labelType.TabIndex = 3;
            this.labelType.Text = "Тип";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("Verdana", 9F);
            this.textBoxName.Location = new System.Drawing.Point(40, 93);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(287, 19);
            this.textBoxName.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9F);
            this.textBox2.Location = new System.Drawing.Point(40, 153);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(287, 19);
            this.textBox2.TabIndex = 6;
            // 
            // checkedListBoxCategory
            // 
            this.checkedListBoxCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkedListBoxCategory.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkedListBoxCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.checkedListBoxCategory.FormattingEnabled = true;
            this.checkedListBoxCategory.Location = new System.Drawing.Point(40, 334);
            this.checkedListBoxCategory.Name = "checkedListBoxCategory";
            this.checkedListBoxCategory.Size = new System.Drawing.Size(420, 130);
            this.checkedListBoxCategory.Sorted = true;
            this.checkedListBoxCategory.TabIndex = 7;
            // 
            // checkedListBoxType
            // 
            this.checkedListBoxType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkedListBoxType.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkedListBoxType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.checkedListBoxType.FormattingEnabled = true;
            this.checkedListBoxType.Location = new System.Drawing.Point(40, 213);
            this.checkedListBoxType.Name = "checkedListBoxType";
            this.checkedListBoxType.Size = new System.Drawing.Size(420, 88);
            this.checkedListBoxType.TabIndex = 8;
            // 
            // buttonAccExit
            // 
            this.buttonAccExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.buttonAccExit.Font = new System.Drawing.Font("Verdana", 9F);
            this.buttonAccExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.buttonAccExit.Location = new System.Drawing.Point(721, 35);
            this.buttonAccExit.Name = "buttonAccExit";
            this.buttonAccExit.Size = new System.Drawing.Size(219, 30);
            this.buttonAccExit.TabIndex = 9;
            this.buttonAccExit.Text = "Выйти из аккаунта";
            this.buttonAccExit.UseVisualStyleBackColor = false;
            this.buttonAccExit.Click += new System.EventHandler(this.buttonAccExit_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btnSaveChanges.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnSaveChanges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.btnSaveChanges.Location = new System.Drawing.Point(721, 592);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(219, 30);
            this.btnSaveChanges.TabIndex = 10;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Личный кабинет";
            // 
            // checkedListBoxAverage
            // 
            this.checkedListBoxAverage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkedListBoxAverage.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkedListBoxAverage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.checkedListBoxAverage.FormattingEnabled = true;
            this.checkedListBoxAverage.Location = new System.Drawing.Point(520, 213);
            this.checkedListBoxAverage.Name = "checkedListBoxAverage";
            this.checkedListBoxAverage.Size = new System.Drawing.Size(420, 88);
            this.checkedListBoxAverage.Sorted = true;
            this.checkedListBoxAverage.TabIndex = 12;
            // 
            // labelFood
            // 
            this.labelFood.AutoSize = true;
            this.labelFood.Font = new System.Drawing.Font("Verdana", 9F);
            this.labelFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelFood.Location = new System.Drawing.Point(517, 313);
            this.labelFood.Name = "labelFood";
            this.labelFood.Size = new System.Drawing.Size(54, 18);
            this.labelFood.TabIndex = 14;
            this.labelFood.Text = "Кухня";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.label2.Location = new System.Drawing.Point(517, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Средний чек";
            // 
            // checkBoxRating
            // 
            this.checkBoxRating.AutoSize = true;
            this.checkBoxRating.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkBoxRating.Location = new System.Drawing.Point(40, 474);
            this.checkBoxRating.Name = "checkBoxRating";
            this.checkBoxRating.Size = new System.Drawing.Size(238, 22);
            this.checkBoxRating.TabIndex = 16;
            this.checkBoxRating.Text = "Заведения с рейтингом 5.0";
            this.checkBoxRating.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxFood
            // 
            this.checkedListBoxFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.checkedListBoxFood.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkedListBoxFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.checkedListBoxFood.FormattingEnabled = true;
            this.checkedListBoxFood.Location = new System.Drawing.Point(520, 334);
            this.checkedListBoxFood.Name = "checkedListBoxFood";
            this.checkedListBoxFood.Size = new System.Drawing.Size(420, 130);
            this.checkedListBoxFood.Sorted = true;
            this.checkedListBoxFood.TabIndex = 13;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(147)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.checkBoxRating);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFood);
            this.Controls.Add(this.checkedListBoxFood);
            this.Controls.Add(this.checkedListBoxAverage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.buttonAccExit);
            this.Controls.Add(this.checkedListBoxType);
            this.Controls.Add(this.checkedListBoxCategory);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategory;
        private System.Windows.Forms.CheckedListBox checkedListBoxType;
        private System.Windows.Forms.Button buttonAccExit;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxAverage;
        private System.Windows.Forms.Label labelFood;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxRating;
        private System.Windows.Forms.CheckedListBox checkedListBoxFood;
    }
}