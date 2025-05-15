//using BankingSystem.Data;
//using BankingSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SQLite;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BankingSystem.Services
//{
//    class TransactionService
//    {
//        private readonly DatabaseHelper _dbHelper;

//        public TransactionService(DatabaseHelper dbHelper)
//        {
//            _dbHelper = dbHelper;
//        }

//        public bool Deposit(int accountId, decimal amount, string description = null)
//        {
//            if (amount <= 0) return false;

//            var connection = new SqliteConnection(_dbHelper.ConnectionString);
//            connection.Open();
//            var transaction = connection.BeginTransaction();

//            try
//            {
//                // Update account balance
//                var updateCommand = connection.CreateCommand();
//                updateCommand.CommandText = @"
//                UPDATE Accounts 
//                SET Balance = Balance + @amount 
//                WHERE AccountId = @accountId";
//                updateCommand.Parameters.AddWithValue("@amount", amount);
//                updateCommand.Parameters.AddWithValue("@accountId", accountId);
//                updateCommand.ExecuteNonQuery();

//                // Record transaction
//                RecordTransaction(connection, accountId, amount, "Deposit", description);

//                transaction.Commit();
//                return true;
//            }
//            catch
//            {
//                transaction.Rollback();
//                return false;
//            }
//        }

//        public bool Withdraw(int accountId, decimal amount, string description = null)
//        {
//            if (amount <= 0) return false;

//            var connection = new SqliteConnection(_dbHelper.ConnectionString);
//            connection.Open();
//            var dbTransaction = connection.BeginTransaction();

//            try
//            {
//                // Check sufficient balance
//                var checkCommand = connection.CreateCommand();
//                checkCommand.CommandText = "SELECT Balance FROM Accounts WHERE AccountId = @accountId";
//                checkCommand.Parameters.AddWithValue("@accountId", accountId);
//                var balance = (decimal)checkCommand.ExecuteScalar();

//                if (balance < amount) return false;

//                // Update account balance
//                var updateCommand = connection.CreateCommand();
//                updateCommand.CommandText = @"
//                UPDATE Accounts 
//                SET Balance = Balance - @amount 
//                WHERE AccountId = @accountId";
//                updateCommand.Parameters.AddWithValue("@amount", amount);
//                updateCommand.Parameters.AddWithValue("@accountId", accountId);
//                updateCommand.ExecuteNonQuery();

//                // Record transaction
//                RecordTransaction(connection, accountId, amount, "Withdrawal", description);

//                dbTransaction.Commit();
//                return true;
//            }
//            catch
//            {
//                dbTransaction.Rollback();
//                return false;
//            }
//        }

//        public bool Transfer(int fromAccountId, int toAccountId, decimal amount, string description = null)
//        {
//            if (amount <= 0) return false;

//            var connection = new SqliteConnection(_dbHelper.ConnectionString);
//            connection.Open();
//            var dbTransaction = connection.BeginTransaction();

//            try
//            {
//                // Check sufficient balance in source account
//                var checkCommand = connection.CreateCommand();
//                checkCommand.CommandText = "SELECT Balance FROM Accounts WHERE AccountId = @accountId";
//                checkCommand.Parameters.AddWithValue("@accountId", fromAccountId);
//                var balance = (decimal)checkCommand.ExecuteScalar();

//                if (balance < amount) return false;

//                // Withdraw from source account
//                var withdrawCommand = connection.CreateCommand();
//                withdrawCommand.CommandText = @"
//                UPDATE Accounts 
//                SET Balance = Balance - @amount 
//                WHERE AccountId = @accountId";
//                withdrawCommand.Parameters.AddWithValue("@amount", amount);
//                withdrawCommand.Parameters.AddWithValue("@accountId", fromAccountId);
//                withdrawCommand.ExecuteNonQuery();

//                // Deposit to target account
//                var depositCommand = connection.CreateCommand();
//                depositCommand.CommandText = @"
//                UPDATE Accounts 
//                SET Balance = Balance + @amount 
//                WHERE AccountId = @accountId";
//                depositCommand.Parameters.AddWithValue("@amount", amount);
//                depositCommand.Parameters.AddWithValue("@accountId", toAccountId);
//                depositCommand.ExecuteNonQuery();

//                // Record transactions
//                RecordTransaction(connection, fromAccountId, amount, "Transfer Out", description);
//                RecordTransaction(connection, toAccountId, amount, "Transfer In", description);

//                dbTransaction.Commit();
//                return true;
//            }
//            catch
//            {
//                dbTransaction.Rollback();
//                return false;
//            }
//        }

//        private void RecordTransaction(SqliteConnection connection, int accountId, decimal amount,
//            string transactionType, string description)
//        {
//            var command = connection.CreateCommand();
//            command.CommandText = @"
//            INSERT INTO Transactions (AccountId, Amount, TransactionType, Description)
//            VALUES (@accountId, @amount, @transactionType, @description)";

//            command.Parameters.AddWithValue("@accountId", accountId);
//            command.Parameters.AddWithValue("@amount", amount);
//            command.Parameters.AddWithValue("@transactionType", transactionType);
//            command.Parameters.AddWithValue("@description", description ?? (object)DBNull.Value);

//            command.ExecuteNonQuery();
//        }

//        public List<Transaction> GetAccountTransactions(int accountId)
//        {
//            var transactions = new List<Transaction>();

//            var connection = new SqliteConnection(_dbHelper.ConnectionString);
//            connection.Open();

//            var command = connection.CreateCommand();
//            command.CommandText = "SELECT * FROM Transactions WHERE AccountId = @accountId ORDER BY TransactionDate DESC";
//            command.Parameters.AddWithValue("@accountId", accountId);

//            var reader = command.ExecuteReader();
//            while (reader.Read())
//            {
//                transactions.Add(new Transaction
//                {
//                    TransactionId = reader.GetInt32(0),
//                    AccountId = reader.GetInt32(1),
//                    Amount = reader.GetDecimal(2),
//                    TransactionType = reader.GetString(3),
//                    Description = reader.IsDBNull(4) ? null : reader.GetString(4),
//                    TransactionDate = reader.GetDateTime(5)
//                });
//            }

//            return transactions;
//        }
//    }
//}
