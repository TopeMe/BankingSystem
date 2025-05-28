using System.Drawing;
using System.Windows.Forms;

namespace BankingSystem.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoimg = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.emailtext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordtext = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoimg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.logoimg);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-10, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 406);
            this.panel1.TabIndex = 0;
            // 
            // logoimg
            // 
            this.logoimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoimg.Image = ((System.Drawing.Image)(resources.GetObject("logoimg.Image")));
            this.logoimg.Location = new System.Drawing.Point(46, 120);
            this.logoimg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logoimg.Name = "logoimg";
            this.logoimg.Size = new System.Drawing.Size(228, 228);
            this.logoimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoimg.TabIndex = 10;
            this.logoimg.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(26, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(356, 81);
            this.label5.TabIndex = 9;
            this.label5.Text = "PHB Online";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(310, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to PHB Online!";
            // 
            // emailtext
            // 
            this.emailtext.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.emailtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailtext.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailtext.Location = new System.Drawing.Point(338, 155);
            this.emailtext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.emailtext.Multiline = true;
            this.emailtext.Name = "emailtext";
            this.emailtext.Size = new System.Drawing.Size(374, 36);
            this.emailtext.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(331, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(331, 193);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 41);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // passwordtext
            // 
            this.passwordtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordtext.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtext.Location = new System.Drawing.Point(333, 228);
            this.passwordtext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordtext.Multiline = true;
            this.passwordtext.Name = "passwordtext";
            this.passwordtext.PasswordChar = '*';  // This is the line to add
            this.passwordtext.Size = new System.Drawing.Size(374, 34);
            this.passwordtext.TabIndex = 4;
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnlogin.ForeColor = System.Drawing.SystemColors.Control;
            this.btnlogin.Location = new System.Drawing.Point(333, 275);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(374, 36);
            this.btnlogin.TabIndex = 6;
            this.btnlogin.Text = "Log In";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(331, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Don\'t have Online Banking yet?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.Highlight;
            this.linkLabel1.Location = new System.Drawing.Point(476, 327);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(54, 17);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sign Up";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 405);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.emailtext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginForm";
            this.Text = "PHB Online";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel panel1;
        private Label label1;
        private TextBox emailtext;
        private Label label2;
        private Label label3;
        private TextBox passwordtext;
        private Button btnlogin;
        private Label label5;
        private Label label4;
        private LinkLabel linkLabel1;
        private PictureBox logoimg;
        private ContextMenuStrip contextMenuStrip1;
    }
}

