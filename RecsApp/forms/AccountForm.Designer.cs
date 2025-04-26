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
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkedListBoxCategory = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxType = new System.Windows.Forms.CheckedListBox();
            this.buttonAccExit = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.listBoxStarredEsts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(56, 74);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(33, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Имя";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(56, 134);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(46, 16);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Логин";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(56, 302);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(75, 16);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Категория";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(56, 194);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(32, 16);
            this.labelType.TabIndex = 3;
            this.labelType.Text = "Тип";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Избранное";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(59, 93);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(287, 22);
            this.textBoxName.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(59, 153);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(287, 22);
            this.textBox2.TabIndex = 6;
            // 
            // checkedListBoxCategory
            // 
            this.checkedListBoxCategory.FormattingEnabled = true;
            this.checkedListBoxCategory.Location = new System.Drawing.Point(59, 321);
            this.checkedListBoxCategory.Name = "checkedListBoxCategory";
            this.checkedListBoxCategory.Size = new System.Drawing.Size(287, 174);
            this.checkedListBoxCategory.TabIndex = 7;
            // 
            // checkedListBoxType
            // 
            this.checkedListBoxType.FormattingEnabled = true;
            this.checkedListBoxType.Location = new System.Drawing.Point(59, 216);
            this.checkedListBoxType.Name = "checkedListBoxType";
            this.checkedListBoxType.Size = new System.Drawing.Size(287, 72);
            this.checkedListBoxType.TabIndex = 8;
            // 
            // buttonAccExit
            // 
            this.buttonAccExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccExit.Location = new System.Drawing.Point(722, 27);
            this.buttonAccExit.Name = "buttonAccExit";
            this.buttonAccExit.Size = new System.Drawing.Size(96, 43);
            this.buttonAccExit.TabIndex = 9;
            this.buttonAccExit.Text = "Выйти из аккаунта";
            this.buttonAccExit.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Location = new System.Drawing.Point(722, 523);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(96, 43);
            this.btnSaveChanges.TabIndex = 10;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // listBoxStarredEsts
            // 
            this.listBoxStarredEsts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxStarredEsts.FormattingEnabled = true;
            this.listBoxStarredEsts.ItemHeight = 16;
            this.listBoxStarredEsts.Location = new System.Drawing.Point(444, 93);
            this.listBoxStarredEsts.Name = "listBoxStarredEsts";
            this.listBoxStarredEsts.Size = new System.Drawing.Size(374, 404);
            this.listBoxStarredEsts.TabIndex = 11;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(882, 603);
            this.Controls.Add(this.listBoxStarredEsts);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.buttonAccExit);
            this.Controls.Add(this.checkedListBoxType);
            this.Controls.Add(this.checkedListBoxCategory);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelName);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategory;
        private System.Windows.Forms.CheckedListBox checkedListBoxType;
        private System.Windows.Forms.Button buttonAccExit;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.ListBox listBoxStarredEsts;
    }
}