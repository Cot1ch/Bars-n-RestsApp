namespace RecsApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateAccount = new System.Windows.Forms.Button();
            this.buttonEntryAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Место для вас";
            // 
            // buttonCreateAccount
            // 
            this.buttonCreateAccount.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonCreateAccount.FlatAppearance.BorderSize = 0;
            this.buttonCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateAccount.Location = new System.Drawing.Point(227, 164);
            this.buttonCreateAccount.Name = "buttonCreateAccount";
            this.buttonCreateAccount.Size = new System.Drawing.Size(141, 42);
            this.buttonCreateAccount.TabIndex = 1;
            this.buttonCreateAccount.Text = "Создать аккаунт";
            this.buttonCreateAccount.UseVisualStyleBackColor = false;
            this.buttonCreateAccount.Click += new System.EventHandler(this.buttonCreateAccount_Click);
            this.buttonCreateAccount.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonCreateAccount_Paint);
            // 
            // buttonEntryAccount
            // 
            this.buttonEntryAccount.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonEntryAccount.FlatAppearance.BorderSize = 0;
            this.buttonEntryAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntryAccount.Location = new System.Drawing.Point(227, 213);
            this.buttonEntryAccount.Name = "buttonEntryAccount";
            this.buttonEntryAccount.Size = new System.Drawing.Size(141, 42);
            this.buttonEntryAccount.TabIndex = 2;
            this.buttonEntryAccount.Text = "Вход";
            this.buttonEntryAccount.UseVisualStyleBackColor = false;
            this.buttonEntryAccount.Click += new System.EventHandler(this.buttonEntryAccount_Click);
            this.buttonEntryAccount.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonEntryAccount_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonEntryAccount);
            this.Controls.Add(this.buttonCreateAccount);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateAccount;
        private System.Windows.Forms.Button buttonEntryAccount;
    }
}

