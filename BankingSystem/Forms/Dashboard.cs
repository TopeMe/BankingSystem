using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using BankingSystem.Forms;
using BankingSystem.Data;

namespace dashboard
{
    public partial class Dashboard : Form
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

        public Dashboard()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 30, 30));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 30, 30));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 30, 30));
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnreq_Click(object sender, EventArgs e)
        {
            btnsend.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnsend.Width, btnsend.Height, 30, 30));
            btnreq.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnreq.Width, btnreq.Height, 30, 30));
            btntransfer.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btntransfer.Width, btntransfer.Height, 30, 30));
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            var dbHelper = new DatabaseHelper(); // Create or get your DatabaseHelper instance
            LoginForm loginForm = new LoginForm(dbHelper);
            loginForm.Show();

            // Close the current dashboard
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
