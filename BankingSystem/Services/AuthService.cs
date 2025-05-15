using BankingSystem.Data;
using System;
using System.Data.SQLite;

namespace BankingSystem.Services
{
    class AuthService
    {
        private readonly DatabaseHelper _dbHelper;

        public AuthService(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public (bool success, string role) Login(string username, string password)
        {
            using (var connection = new SQLiteConnection(_dbHelper.ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT Password, Role FROM Users WHERE Username = @username", connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var storedPassword = reader.GetString(0);
                            var role = reader.GetString(1);

                            if (VerifyPassword(password, storedPassword))
                            {
                                return (true, role);
                            }
                        }
                    }
                }
            }

            return (false, null);
        }


        private bool VerifyPassword(string password, string storedPassword)
        {
            return password == storedPassword;
        }
    }
}
