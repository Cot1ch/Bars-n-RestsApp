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
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(167, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(556, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создание аккаунта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.label2.Location = new System.Drawing.Point(293, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите имя";
            // 
            // richTextBoxCreateName
            // 
            this.richTextBoxCreateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.richTextBoxCreateName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCreateName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCreateName.Location = new System.Drawing.Point(313, 244);
            this.richTextBoxCreateName.Name = "richTextBoxCreateName";
            this.richTextBoxCreateName.Size = new System.Drawing.Size(248, 31);
            this.richTextBoxCreateName.TabIndex = 3;
            this.richTextBoxCreateName.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.label3.Location = new System.Drawing.Point(293, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Придумайте логин";
            // 
            // richTextBoxCreateLogin
            // 
            this.richTextBoxCreateLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.richTextBoxCreateLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCreateLogin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCreateLogin.Location = new System.Drawing.Point(313, 312);
            this.richTextBoxCreateLogin.Name = "richTextBoxCreateLogin";
            this.richTextBoxCreateLogin.Size = new System.Drawing.Size(248, 31);
            this.richTextBoxCreateLogin.TabIndex = 5;
            this.richTextBoxCreateLogin.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.label4.Location = new System.Drawing.Point(293, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Придумайте пароль";
            // 
            // richTextBoxCreatePassword
            // 
            this.richTextBoxCreatePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.richTextBoxCreatePassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCreatePassword.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCreatePassword.Location = new System.Drawing.Point(313, 379);
            this.richTextBoxCreatePassword.Name = "richTextBoxCreatePassword";
            this.richTextBoxCreatePassword.Size = new System.Drawing.Size(248, 31);
            this.richTextBoxCreatePassword.TabIndex = 7;
            this.richTextBoxCreatePassword.Text = "";
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.buttonCreate.Location = new System.Drawing.Point(359, 438);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(160, 28);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            this.buttonCreate.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonCreate_Paint);
            // 
            // buttonBFCA
            // 
            this.buttonBFCA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.buttonBFCA.FlatAppearance.BorderSize = 0;
            this.buttonBFCA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBFCA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonBFCA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
            this.buttonBFCA.Location = new System.Drawing.Point(13, 13);
            this.buttonBFCA.Name = "buttonBFCA";
            this.buttonBFCA.Size = new System.Drawing.Size(75, 23);
            this.buttonBFCA.TabIndex = 9;
            this.buttonBFCA.Text = "Назад";
            this.buttonBFCA.UseVisualStyleBackColor = false;
            this.buttonBFCA.Click += new System.EventHandler(this.buttonBFCA_Click);
            this.buttonBFCA.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonBFCA_Paint);
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 611);
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