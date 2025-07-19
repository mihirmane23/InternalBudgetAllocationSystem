using InternalBudgetAllocationSystem.DAL.Interfaces;
using InternalBudgetAllocationSystem.Models;
using Npgsql;
using System.Data;

namespace InternalBudgetAllocationSystem.DAL.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly string _connectionString;

        public BudgetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Budget> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("SELECT * FROM Budgets WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Budget
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId")),
                    BudgetName = reader.GetString(reader.GetOrdinal("BudgetName")),
                    Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                    Currency = reader.GetString(reader.GetOrdinal("Currency")),
                    StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                    EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    CreatedBy = reader.GetString(reader.GetOrdinal("CreatedBy")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    LastModifiedBy = reader.GetString(reader.GetOrdinal("LastModifiedBy")),
                    LastModifiedAt = reader.GetDateTime(reader.GetOrdinal("LastModifiedAt"))
                };
            }
            return null;
        }

        public async Task<List<Budget>> GetAllAsync()
        {
            var budgets = new List<Budget>();
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("SELECT * FROM Budgets", connection);
            using var reader = await command.ExecuteReaderAsync();

            while(await reader.ReadAsync())
            {
                budgets.Add(new Budget
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId")),
                    BudgetName = reader.GetString(reader.GetOrdinal("BudgetName")),
                    Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                    Currency = reader.GetString(reader.GetOrdinal("Currency")),
                    StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                    EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    CreatedBy = reader.GetString(reader.GetOrdinal("CreatedBy")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    LastModifiedBy = reader.GetString(reader.GetOrdinal("LastModifiedBy")),
                    LastModifiedAt = reader.GetDateTime(reader.GetOrdinal("LastModifiedAt"))
                });
            }
            return budgets;
        }

        public async Task CreateAsync(Budget budget)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("INSERT INTO Budges (DepartmentId, BudgetName, Amount, Currency, StartDate, EndDate, Status, CreatedBy, CreatedAt, LastModifiedBy, LastModifiedAt) VALUES (@DepartmentId, @BudgetName, @Amount, @Currency, @StartDate, @EndDate, @Status, @CreatedBy, @CreatedAt, @LastModifiedBy, @LastModifiedAt)", connection);
            command.Parameters.AddWithValue("DepartmentId", budget.DepartmentId);
            command.Parameters.AddWithValue("BudgetName", budget.BudgetName);
            command.Parameters.AddWithValue("Amount", budget.Amount);
            command.Parameters.AddWithValue("Currency", budget.Currency);
            command.Parameters.AddWithValue("StartDate", budget.StartDate);
            command.Parameters.AddWithValue("EndDate", budget.EndDate);
            command.Parameters.AddWithValue("Status", budget.Status);
            command.Parameters.AddWithValue("CreatedBy", budget.CreatedBy);
            command.Parameters.AddWithValue("CreatedAt", budget.CreatedAt);
            command.Parameters.AddWithValue("LastModifiedBy", budget.LastModifiedBy);
            command.Parameters.AddWithValue("LastModifiedAt", budget.LastModifiedAt);

            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(Budget budget)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("UPDATE Budgets SET DepartmentId = @DepartmentId, BudgetName = @BudgetName, Amount = @Amount, Currency = @Currency, StartDate = @StartDate, EndDate = @EndDate, Status = @Status, LastModifiedBy = @LastModifiedBy, LastModifiedAt = @LastModifiedAt WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("Id", budget.Id);
            command.Parameters.AddWithValue("DepartmentId", budget.DepartmentId);
            command.Parameters.AddWithValue("BudgetName", budget.BudgetName);
            command.Parameters.AddWithValue("Amount", budget.Amount);
            command.Parameters.AddWithValue("Currency", budget.Currency);
            command.Parameters.AddWithValue("StartDate", budget.StartDate);
            command.Parameters.AddWithValue("EndDate", budget.EndDate);
            command.Parameters.AddWithValue("Status", budget.Status);
            command.Parameters.AddWithValue("LastModifiedBy", budget.LastModifiedBy);
            command.Parameters.AddWithValue("LastModifiedAt", budget.LastModifiedAt);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("DELETE FROM Budgets WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("Id", id);
            await command.ExecuteNonQueryAsync();
        }
    }
}
