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
    }
}
