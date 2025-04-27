namespace RecsApp.forms
{
    partial class EntryAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxEntryLogin = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxEntryPassword = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEntry = new System.Windows.Forms.Button();
            this.buttonBFEA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вход в аккаунт";
            // 
            // richTextBoxEntryLogin
            // 
            this.richTextBoxEntryLogin.Location = new System.Drawing.Point(314, 177);
            this.richTextBoxEntryLogin.Name = "richTextBoxEntryLogin";
            this.richTextBoxEntryLogin.Size = new System.Drawing.Size(140, 33);
            this.richTextBoxEntryLogin.TabIndex = 1;
            this.richTextBoxEntryLogin.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите логин";
            // 
            // richTextBoxEntryPassword
            // 
            this.richTextBoxEntryPassword.Location = new System.Drawing.Point(314, 251);
            this.richTextBoxEntryPassword.Name = "richTextBoxEntryPassword";
            this.richTextBoxEntryPassword.Size = new System.Drawing.Size(140, 33);
            this.richTextBoxEntryPassword.TabIndex = 3;
            this.richTextBoxEntryPassword.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Введите пароль";
            // 
            // buttonEntry
            // 
            this.buttonEntry.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonEntry.FlatAppearance.BorderSize = 0;
            this.buttonEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntry.Location = new System.Drawing.Point(343, 308);
            this.buttonEntry.Name = "buttonEntry";
            this.buttonEntry.Size = new System.Drawing.Size(75, 32);
            this.buttonEntry.TabIndex = 5;
            this.buttonEntry.Text = "Войти";
            this.buttonEntry.UseVisualStyleBackColor = false;
            this.buttonEntry.Click += new System.EventHandler(this.buttonEntry_Click);
            this.buttonEntry.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonEntry_Paint);
            // 
            // buttonBFEA
            // 
            this.buttonBFEA.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonBFEA.FlatAppearance.BorderSize = 0;
            this.buttonBFEA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBFEA.Location = new System.Drawing.Point(13, 13);
            this.buttonBFEA.Name = "buttonBFEA";
            this.buttonBFEA.Size = new System.Drawing.Size(75, 23);
            this.buttonBFEA.TabIndex = 6;
            this.buttonBFEA.Text = "Назад";
            this.buttonBFEA.UseVisualStyleBackColor = false;
            this.buttonBFEA.Click += new System.EventHandler(this.buttonBFEA_Click);
            // 
            // EntryAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBFEA);
            this.Controls.Add(this.buttonEntry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxEntryPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxEntryLogin);
            this.Controls.Add(this.label1);
            this.Name = "EntryAccount";
            this.Text = "Вход в аккаунт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxEntryLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxEntryPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEntry;
        private System.Windows.Forms.Button buttonBFEA;
    }
}