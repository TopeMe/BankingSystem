using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using BankingSystem.Data;

namespace BankingSystem.Forms
{
    public partial class Admin : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private string _currentTable = "";
        private DataTable _dataTable = new DataTable();
        private bool _isDirty = false;

        public Admin(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewTables.AutoGenerateColumns = true;
            dataGridViewTables.AllowUserToAddRows = true;
            dataGridViewTables.AllowUserToDeleteRows = true;
            dataGridViewTables.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dataGridViewTables.CellBeginEdit += (s, e) => _isDirty = true;
            dataGridViewTables.UserDeletingRow += (s, e) => _isDirty = true;
            dataGridViewTables.DataError += DataGridViewTables_DataError;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            comboBoxTables.SelectedIndex = 0;
            LoadTableData(comboBoxTables.SelectedItem.ToString());
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isDirty)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save before switching tables?",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveChanges();
                }
                else if (result == DialogResult.Cancel)
                {
                    comboBoxTables.SelectedItem = _currentTable;
                    return;
                }
            }
            LoadTableData(comboBoxTables.SelectedItem.ToString());
        }

        private void LoadTableData(string tableName)
        {
            try
            {
                using (var connection = _dbHelper.CreateConnection())
                {
                    _currentTable = tableName;
                    string query = $"SELECT * FROM {tableName}";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        var commandBuilder = new SQLiteCommandBuilder(adapter);
                        adapter.InsertCommand = commandBuilder.GetInsertCommand();
                        adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                        adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                        _dataTable = new DataTable();  
                        adapter.Fill(_dataTable);

    
                        switch (tableName)
                        {
                            case "Accounts":
                                _dataTable.PrimaryKey = new[] { _dataTable.Columns["AccountId"] };
                                break;
                            case "Customers":
                                _dataTable.PrimaryKey = new[] { _dataTable.Columns["CustomerId"] };
                                break;
                            case "Transactions":
                                _dataTable.PrimaryKey = new[] { _dataTable.Columns["TransactionId"] };
                                break;
                            case "Users":
                                _dataTable.PrimaryKey = new[] { _dataTable.Columns["UserId"] };
                                break;
                        }

                        dataGridViewTables.DataSource = _dataTable;
                        _isDirty = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading table: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                using (var connection = _dbHelper.CreateConnection())
                {
                    
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string query = $"SELECT * FROM {_currentTable} WHERE 1=0"; 

                            using (var adapter = new SQLiteDataAdapter(query, connection))
                            {
                                var commandBuilder = new SQLiteCommandBuilder(adapter)
                                {
                                    ConflictOption = ConflictOption.OverwriteChanges
                                };

                                
                                adapter.InsertCommand = commandBuilder.GetInsertCommand();
                                adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                                adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                                
                                DataTable changes = _dataTable.GetChanges();

                                if (changes != null)
                                {
                                    int rowsAffected = adapter.Update(changes);
                                    transaction.Commit();

                                    MessageBox.Show($"{rowsAffected} records updated successfully.", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    _dataTable.AcceptChanges();
                                    _isDirty = false;
                                }
                                else
                                {
                                    MessageBox.Show("No changes to save.", "Information",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw; 
                        }
                    }
                }
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}\nError Code: {sqlEx.ErrorCode}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}\n\n{ex.InnerException?.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_isDirty)
            {
                var result = MessageBox.Show("You have unsaved changes. Refresh anyway?",
                    "Unsaved Changes", MessageBoxButtons.YesNo);

                if (result != DialogResult.Yes) return;
            }
            LoadTableData(_currentTable);
        }

        private void DataGridViewTables_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Data error: {e.Exception.Message}", "Input Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save before exiting?",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveChanges();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dbHelper = new DatabaseHelper();
            LoginForm loginForm = new LoginForm(dbHelper);
            loginForm.Show();
            this.Close();
        }
    }
}