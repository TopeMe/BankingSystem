using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace BankingSystem.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;
        public string ConnectionString => _connectionString;

        public DatabaseHelper(string dbPath = "BankingSystem.db")
        {
            _connectionString = $"Data Source={dbPath}";

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            connection.Open();
            ExecuteNonQuery(@"
            CREATE TABLE IF NOT EXISTS Customers (
                CustomerId INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL,
                Email TEXT NOT NULL UNIQUE,
                Phone TEXT,
                DateCreated TEXT DEFAULT CURRENT_TIMESTAMP
            )");

            ExecuteNonQuery(@"
            CREATE TABLE IF NOT EXISTS Accounts (
                AccountId INTEGER PRIMARY KEY AUTOINCREMENT,
                CustomerId INTEGER NOT NULL,
                AccountType TEXT NOT NULL,
                Balance DECIMAL(18,2) DEFAULT 0.00,
                DateOpened TEXT DEFAULT CURRENT_TIMESTAMP,
                FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
            )");

            ExecuteNonQuery(@"
            CREATE TABLE IF NOT EXISTS Transactions (
                TransactionId INTEGER PRIMARY KEY AUTOINCREMENT,
                AccountId INTEGER NOT NULL,
                Amount DECIMAL(18,2) NOT NULL,
                TransactionType TEXT NOT NULL,
                Description TEXT,
                TransactionDate TEXT DEFAULT CURRENT_TIMESTAMP,
                FOREIGN KEY (AccountId) REFERENCES Accounts(AccountId)
            )");

            ExecuteNonQuery(@"
            CREATE TABLE IF NOT EXISTS Users (
                UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                CustomerId INTEGER,
                Username TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL,
                Role TEXT NOT NULL,
                FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
            )");
        }

        private void ExecuteNonQuery(string commandText)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
