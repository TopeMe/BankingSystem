using BankingSystem.Data;
using BankingSystem.Models;
using BankingSystem.Services;
using dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BankingSystem.Forms
{
    public partial class LoginForm: Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeft,
        int nTop,
        int nRight,
        int nBottom,
        int nWidthEllipse,
        int nHeightEllipse
    );
        private readonly Data.DatabaseHelper _dbHelper;
   
        public LoginForm(Data.DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            emailtext.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnlogin.Width, btnlogin.Height, 30, 30));
            passwordtext.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnlogin.Width, btnlogin.Height, 30, 30));
        }

        private void btnlogin_Click(object sender, EventArgs e)

        {
            var username = emailtext.Text.Trim();
            var password = passwordtext.Text;

            var dbHelper = new DatabaseHelper(); 
            var authService = new AuthService(dbHelper);

            var (success, role, customer) = authService.Login(username, password);

            if (success)
            {
                MessageBox.Show($"Login successful! Role: {role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dashboard dashboard = new Dashboard(customer);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
