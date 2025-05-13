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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryAccount));
            this.labelEntryAccount = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonEntry = new System.Windows.Forms.Button();
            this.buttonBFEA = new System.Windows.Forms.Button();
            this.richTextBoxEntryLogin = new System.Windows.Forms.RichTextBox();
            this.textBoxEntryPassword = new System.Windows.Forms.TextBox();
            this.pictureBoxShowEntryPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowEntryPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEntryAccount
            // 
            this.labelEntryAccount.AutoSize = true;
            this.labelEntryAccount.BackColor = System.Drawing.Color.Transparent;
            this.labelEntryAccount.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEntryAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelEntryAccount.Location = new System.Drawing.Point(233, 186);
            this.labelEntryAccount.Name = "labelEntryAccount";
            this.labelEntryAccount.Size = new System.Drawing.Size(594, 78);
            this.labelEntryAccount.TabIndex = 0;
            this.labelEntryAccount.Text = "Вход в аккаунт";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelLogin.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelLogin.Location = new System.Drawing.Point(398, 308);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(128, 18);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "Введите логин";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelPassword.Location = new System.Drawing.Point(398, 394);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(142, 18);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Введите пароль";
            // 
            // buttonEntry
            // 
            this.buttonEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.buttonEntry.FlatAppearance.BorderSize = 0;
            this.buttonEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.buttonEntry.Location = new System.Drawing.Point(484, 515);
            this.buttonEntry.Name = "buttonEntry";
            this.buttonEntry.Size = new System.Drawing.Size(134, 24);
            this.buttonEntry.TabIndex = 5;
            this.buttonEntry.Text = "Войти";
            this.buttonEntry.UseVisualStyleBackColor = false;
            this.buttonEntry.Click += new System.EventHandler(this.buttonEntry_Click);
            // 
            // buttonBFEA
            // 
            this.buttonBFEA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.buttonBFEA.FlatAppearance.BorderSize = 0;
            this.buttonBFEA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBFEA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonBFEA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.buttonBFEA.Location = new System.Drawing.Point(13, 13);
            this.buttonBFEA.Name = "buttonBFEA";
            this.buttonBFEA.Size = new System.Drawing.Size(75, 23);
            this.buttonBFEA.TabIndex = 6;
            this.buttonBFEA.Text = "Назад";
            this.buttonBFEA.UseVisualStyleBackColor = false;
            this.buttonBFEA.Click += new System.EventHandler(this.buttonBFEA_Click);
            // 
            // richTextBoxEntryLogin
            // 
            this.richTextBoxEntryLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.richTextBoxEntryLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxEntryLogin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxEntryLogin.Location = new System.Drawing.Point(401, 329);
            this.richTextBoxEntryLogin.Name = "richTextBoxEntryLogin";
            this.richTextBoxEntryLogin.Size = new System.Drawing.Size(284, 37);
            this.richTextBoxEntryLogin.TabIndex = 1;
            this.richTextBoxEntryLogin.Text = "";
            // 
            // textBoxEntryPassword
            // 
            this.textBoxEntryPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxEntryPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEntryPassword.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEntryPassword.Location = new System.Drawing.Point(401, 415);
            this.textBoxEntryPassword.Multiline = true;
            this.textBoxEntryPassword.Name = "textBoxEntryPassword";
            this.textBoxEntryPassword.PasswordChar = '*';
            this.textBoxEntryPassword.Size = new System.Drawing.Size(284, 37);
            this.textBoxEntryPassword.TabIndex = 7;
            // 
            // pictureBoxShowEntryPassword
            // 
            this.pictureBoxShowEntryPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.pictureBoxShowEntryPassword.BackgroundImage = global::RecsApp.Properties.Resources.visible_password_security_protect_icon;
            this.pictureBoxShowEntryPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxShowEntryPassword.Location = new System.Drawing.Point(648, 415);
            this.pictureBoxShowEntryPassword.Name = "pictureBoxShowEntryPassword";
            this.pictureBoxShowEntryPassword.Size = new System.Drawing.Size(37, 37);
            this.pictureBoxShowEntryPassword.TabIndex = 8;
            this.pictureBoxShowEntryPassword.TabStop = false;
            this.pictureBoxShowEntryPassword.Click += new System.EventHandler(this.pictureBoxShowEntryPassword_Click);
            // 
            // EntryAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 761);
            this.Controls.Add(this.pictureBoxShowEntryPassword);
            this.Controls.Add(this.textBoxEntryPassword);
            this.Controls.Add(this.buttonBFEA);
            this.Controls.Add(this.buttonEntry);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.richTextBoxEntryLogin);
            this.Controls.Add(this.labelEntryAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EntryAccount";
            this.Text = "Вход в аккаунт";
            this.Load += new System.EventHandler(this.EntryAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowEntryPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEntryAccount;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonEntry;
        private System.Windows.Forms.Button buttonBFEA;
        private System.Windows.Forms.RichTextBox richTextBoxEntryLogin;
        private System.Windows.Forms.TextBox textBoxEntryPassword;
        private System.Windows.Forms.PictureBox pictureBoxShowEntryPassword;
    }
}