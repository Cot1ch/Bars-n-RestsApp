namespace RecsApp.forms
{
    partial class CreateAccount
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
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxCreateName = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxCreateLogin = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxCreatePassword = new System.Windows.Forms.RichTextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonBFCA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создание аккаунта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите имя";
            // 
            // richTextBoxCreateName
            // 
            this.richTextBoxCreateName.Location = new System.Drawing.Point(297, 143);
            this.richTextBoxCreateName.Name = "richTextBoxCreateName";
            this.richTextBoxCreateName.Size = new System.Drawing.Size(163, 31);
            this.richTextBoxCreateName.TabIndex = 3;
            this.richTextBoxCreateName.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Придумайте логин";
            // 
            // richTextBoxCreateLogin
            // 
            this.richTextBoxCreateLogin.Location = new System.Drawing.Point(297, 215);
            this.richTextBoxCreateLogin.Name = "richTextBoxCreateLogin";
            this.richTextBoxCreateLogin.Size = new System.Drawing.Size(163, 31);
            this.richTextBoxCreateLogin.TabIndex = 5;
            this.richTextBoxCreateLogin.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Придумайте пароль";
            // 
            // richTextBoxCreatePassword
            // 
            this.richTextBoxCreatePassword.Location = new System.Drawing.Point(297, 281);
            this.richTextBoxCreatePassword.Name = "richTextBoxCreatePassword";
            this.richTextBoxCreatePassword.Size = new System.Drawing.Size(163, 31);
            this.richTextBoxCreatePassword.TabIndex = 7;
            this.richTextBoxCreatePassword.Text = "";
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreate.Location = new System.Drawing.Point(331, 350);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(88, 32);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            this.buttonCreate.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonCreate_Paint);
            // 
            // buttonBFCA
            // 
            this.buttonBFCA.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonBFCA.FlatAppearance.BorderSize = 0;
            this.buttonBFCA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBFCA.Location = new System.Drawing.Point(13, 13);
            this.buttonBFCA.Name = "buttonBFCA";
            this.buttonBFCA.Size = new System.Drawing.Size(75, 23);
            this.buttonBFCA.TabIndex = 9;
            this.buttonBFCA.Text = "Назад";
            this.buttonBFCA.UseVisualStyleBackColor = false;
            this.buttonBFCA.Click += new System.EventHandler(this.buttonBFCA_Click);
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBFCA);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.richTextBoxCreatePassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBoxCreateLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxCreateName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateAccount";
            this.Text = "Создание аккаунта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxCreateName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxCreateLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxCreatePassword;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonBFCA;
    }
}