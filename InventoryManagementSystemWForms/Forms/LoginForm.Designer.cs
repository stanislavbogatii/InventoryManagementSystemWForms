namespace InventoryManagementSystemWForms
{
    partial class LoginForm
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
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            PasswordBox = new TextBox();
            UsernameBox = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            Login = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(PasswordBox);
            panel1.Controls.Add(UsernameBox);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16F);
            button2.Location = new Point(395, 299);
            button2.Name = "button2";
            button2.Size = new Size(160, 39);
            button2.TabIndex = 7;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16F);
            button1.Location = new Point(235, 299);
            button1.Name = "button1";
            button1.Size = new Size(154, 39);
            button1.TabIndex = 6;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            // 
            // PasswordBox
            // 
            PasswordBox.Font = new Font("Microsoft Sans Serif", 14.25F);
            PasswordBox.Location = new Point(273, 239);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(282, 29);
            PasswordBox.TabIndex = 5;
            PasswordBox.UseSystemPasswordChar = true;
            // 
            // UsernameBox
            // 
            UsernameBox.Font = new Font("Microsoft Sans Serif", 14.25F);
            UsernameBox.Location = new Point(273, 183);
            UsernameBox.Multiline = true;
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(282, 32);
            UsernameBox.TabIndex = 4;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.padlock;
            pictureBox3.Location = new Point(235, 239);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(235, 183);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(Login);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 100);
            panel2.TabIndex = 0;
            // 
            // Login
            // 
            Login.Dock = DockStyle.Fill;
            Login.Font = new Font("Consolas", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Login.Location = new Point(0, 0);
            Login.Name = "Login";
            Login.Size = new Size(800, 100);
            Login.TabIndex = 0;
            Login.Text = "LOGIN";
            Login.TextAlign = ContentAlignment.MiddleCenter;
            Login.Click += label1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "Inventory Management";
            Load += LoginForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label Login;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private TextBox PasswordBox;
        private TextBox UsernameBox;
        private Button button2;
        private Button button1;
    }
}