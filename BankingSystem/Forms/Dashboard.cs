using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using BankingSystem.Forms;
using BankingSystem.Data;
using BankingSystem.Models;
using System.Data.SQLite;

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

        private Customer _customer;
        private readonly DatabaseHelper _dbHelper;
        public Dashboard(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            _dbHelper = new DatabaseHelper();
        }


        private void btnreq_Click(object sender, EventArgs e)
        {
            btntransfer.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btntransfer.Width, btntransfer.Height, 30, 30));
        }


        private void label14_Click_1(object sender, EventArgs e)
        {
            var dbHelper = new DatabaseHelper();
            LoginForm loginForm = new LoginForm(dbHelper);
            loginForm.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 30, 30));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 30, 30));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 30, 30));
            if (_customer != null)
            {
                //User information
                label11.Text = _customer.FirstName;
                label4.Text = _customer.LastName;
                label13.Text = _customer.Email;
                label22.Text = _customer.Phone;
                label23.Text = _customer.DateCreated.ToString();
                //Accoutn information
                string query = "SELECT AccountId, AccountType, Balance, DateOpened FROM Accounts WHERE CustomerId = @CustomerId";

                using (var connection = new SQLiteConnection(_dbHelper.ConnectionString))
                using (var command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@CustomerId", _customer.CustomerId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
   
                            label7.Text = $"₱{Convert.ToDecimal(reader["Balance"]):0.00}";
                            label24.Text = reader["AccountId"].ToString();
                            string accountType = reader["AccountType"].ToString();
                            DateTime dateOpened = Convert.ToDateTime(reader["DateOpened"]);
                        }
                        else
                        {
      
                            label7.Text = "₱0.00";
                            label24.Text = "N/A";
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Customer is null.");
            }
        }

    }
}
