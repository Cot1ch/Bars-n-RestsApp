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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccount));
            this.labelCreateAccount = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.richTextBoxCreateName = new System.Windows.Forms.RichTextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.richTextBoxCreateLogin = new System.Windows.Forms.RichTextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonBFCA = new System.Windows.Forms.Button();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.pbShowPassword = new System.Windows.Forms.PictureBox();
            this.textBoxCreatePassword = new System.Windows.Forms.TextBox();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.pbConfirmPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCreateAccount
            // 
            this.labelCreateAccount.BackColor = System.Drawing.Color.Transparent;
            this.labelCreateAccount.Font = new System.Drawing.Font("Verdana", 38F, System.Drawing.FontStyle.Bold);
            this.labelCreateAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelCreateAccount.Location = new System.Drawing.Point(162, 156);
            this.labelCreateAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreateAccount.Name = "labelCreateAccount";
            this.labelCreateAccount.Size = new System.Drawing.Size(742, 78);
            this.labelCreateAccount.TabIndex = 0;
            this.labelCreateAccount.Text = "Создание аккаунта";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelName.Location = new System.Drawing.Point(335, 248);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(111, 18);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Введите имя";
            // 
            // richTextBoxCreateName
            // 
            this.richTextBoxCreateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.richTextBoxCreateName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCreateName.Font = new System.Drawing.Font("Verdana", 11F);
            this.richTextBoxCreateName.Location = new System.Drawing.Point(338, 270);
            this.richTextBoxCreateName.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxCreateName.Multiline = false;
            this.richTextBoxCreateName.Name = "richTextBoxCreateName";
            this.richTextBoxCreateName.Size = new System.Drawing.Size(379, 38);
            this.richTextBoxCreateName.TabIndex = 3;
            this.richTextBoxCreateName.Text = "";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelLogin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelLogin.Location = new System.Drawing.Point(335, 324);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(299, 18);
            this.labelLogin.TabIndex = 4;
            this.labelLogin.Text = "Придумайте логин (от 6 символов)";
            // 
            // richTextBoxCreateLogin
            // 
            this.richTextBoxCreateLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.richTextBoxCreateLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCreateLogin.Font = new System.Drawing.Font("Verdana", 11F);
            this.richTextBoxCreateLogin.Location = new System.Drawing.Point(338, 346);
            this.richTextBoxCreateLogin.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxCreateLogin.Multiline = false;
            this.richTextBoxCreateLogin.Name = "richTextBoxCreateLogin";
            this.richTextBoxCreateLogin.Size = new System.Drawing.Size(379, 38);
            this.richTextBoxCreateLogin.TabIndex = 5;
            this.richTextBoxCreateLogin.Text = "";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelPassword.Location = new System.Drawing.Point(335, 400);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(313, 18);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Придумайте пароль (от 6 символов)";
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            this.buttonCreate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.buttonCreate.Location = new System.Drawing.Point(421, 570);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(200, 40);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonBFCA
            // 
            this.buttonBFCA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.buttonBFCA.FlatAppearance.BorderSize = 0;
            this.buttonBFCA.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.buttonBFCA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.buttonBFCA.Location = new System.Drawing.Point(17, 16);
            this.buttonBFCA.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBFCA.Name = "buttonBFCA";
            this.buttonBFCA.Size = new System.Drawing.Size(100, 30);
            this.buttonBFCA.TabIndex = 9;
            this.buttonBFCA.Text = "Назад";
            this.buttonBFCA.UseVisualStyleBackColor = false;
            this.buttonBFCA.Click += new System.EventHandler(this.buttonBFCA_Click);
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.labelConfirmPassword.Location = new System.Drawing.Point(335, 479);
            this.labelConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(181, 18);
            this.labelConfirmPassword.TabIndex = 10;
            this.labelConfirmPassword.Text = "Подтвердите пароль";
            // 
            // pbShowPassword
            // 
            this.pbShowPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.pbShowPassword.BackgroundImage = global::RecsApp.Properties.Resources.visible_password_security_protect_icon;
            this.pbShowPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbShowPassword.Location = new System.Drawing.Point(679, 422);
            this.pbShowPassword.Margin = new System.Windows.Forms.Padding(4);
            this.pbShowPassword.Name = "pbShowPassword";
            this.pbShowPassword.Size = new System.Drawing.Size(38, 38);
            this.pbShowPassword.TabIndex = 12;
            this.pbShowPassword.TabStop = false;
            this.pbShowPassword.Click += new System.EventHandler(this.pbShowPassword_Click);
            // 
            // textBoxCreatePassword
            // 
            this.textBoxCreatePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxCreatePassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCreatePassword.Font = new System.Drawing.Font("Verdana", 11F);
            this.textBoxCreatePassword.Location = new System.Drawing.Point(338, 422);
            this.textBoxCreatePassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCreatePassword.Multiline = true;
            this.textBoxCreatePassword.Name = "textBoxCreatePassword";
            this.textBoxCreatePassword.PasswordChar = '*';
            this.textBoxCreatePassword.Size = new System.Drawing.Size(379, 38);
            this.textBoxCreatePassword.TabIndex = 13;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.textBoxConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConfirmPassword.Font = new System.Drawing.Font("Verdana", 11F);
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(338, 501);
            this.textBoxConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConfirmPassword.Multiline = true;
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(379, 38);
            this.textBoxConfirmPassword.TabIndex = 14;
            // 
            // pbConfirmPassword
            // 
            this.pbConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.pbConfirmPassword.BackgroundImage = global::RecsApp.Properties.Resources.visible_password_security_protect_icon;
            this.pbConfirmPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbConfirmPassword.Location = new System.Drawing.Point(679, 501);
            this.pbConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.pbConfirmPassword.Name = "pbConfirmPassword";
            this.pbConfirmPassword.Size = new System.Drawing.Size(38, 38);
            this.pbConfirmPassword.TabIndex = 15;
            this.pbConfirmPassword.TabStop = false;
            this.pbConfirmPassword.Click += new System.EventHandler(this.pbConfirmPassword_Click);
            // 
            // CreateAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.pbConfirmPassword);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.pbShowPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.buttonBFCA);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.richTextBoxCreateLogin);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.richTextBoxCreateName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelCreateAccount);
            this.Controls.Add(this.textBoxCreatePassword);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CreateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание аккаунта";
            ((System.ComponentModel.ISupportInitialize)(this.pbShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCreateAccount;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.RichTextBox richTextBoxCreateName;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.RichTextBox richTextBoxCreateLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonBFCA;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.PictureBox pbShowPassword;
        private System.Windows.Forms.TextBox textBoxCreatePassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.PictureBox pbConfirmPassword;
    }
}