namespace Password_Verification
{
    partial class Form1
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
            this.background = new System.ComponentModel.BackgroundWorker();
            this.Register = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.usernamelogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.usernamelogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Register
            // 
            this.Register.AutoSize = true;
            this.Register.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register.ForeColor = System.Drawing.Color.Red;
            this.Register.Location = new System.Drawing.Point(66, 65);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(238, 33);
            this.Register.TabIndex = 0;
            this.Register.Text = "Create Account";
            this.Register.Click += new System.EventHandler(this.label1_Click);
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Username.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Username.Location = new System.Drawing.Point(72, 205);
            this.Username.Multiline = true;
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(243, 45);
            this.Username.TabIndex = 1;
            this.Username.Text = "        Name";
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // usernamelogo
            // 
            this.usernamelogo.ImageLocation = "C:\\Users\\ItsAl\\Desktop\\usernamelogo.png";
            this.usernamelogo.Location = new System.Drawing.Point(51, 189);
            this.usernamelogo.Name = "usernamelogo";
            this.usernamelogo.Size = new System.Drawing.Size(60, 70);
            this.usernamelogo.TabIndex = 2;
            this.usernamelogo.TabStop = false;
            this.usernamelogo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 636);
            this.Controls.Add(this.usernamelogo);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.Register);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.usernamelogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker background;
        private System.Windows.Forms.Label Register;
        private System.Windows.Forms.TextBox Username;
        public System.Windows.Forms.PictureBox usernamelogo;
    }
}

