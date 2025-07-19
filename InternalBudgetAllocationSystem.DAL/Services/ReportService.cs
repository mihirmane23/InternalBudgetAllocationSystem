using InternalBudgetAllocationSystem.DAL.Interfaces;
using InternalBudgetAllocationSystem.Models;
using Npgsql;
using System.Data;

namespace InternalBudgetAllocationSystem.DAL.Services
{
    public class ReportService : IReportService
    {
        private readonly string _connectionString;

        public ReportService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<BudgetReport>> GetBudgetReportsAsync()
        {
            var reports = new List<BudgetReport>();
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            
            using var command = new NpgsqlCommand("SELECT b.Id AS BudgetId, b.BudgetName, d.Name AS DepartmentName, b.Amount, b.Currency, b.Status, b.StartDate, b.EndDate ROM Budgets b JOIN Departments d ON b.DepartmentId = d.Id", connection);
            
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                reports.Add(new BudgetReport
                {
                    BudgetId = reader.GetInt32("BudgetId"),
                    BudgetName = reader.GetString("BudgetName"),
                    DepartmentName = reader.GetString("DepartmentName"),
                    Amount = reader.GetDecimal("Amount"),
                    Currency = reader.GetString("Currency"),
                    Status = reader.GetString("Status"),
                    StartDate = reader.GetDateTime("StartDate"),
                    EndDate = reader.GetDateTime("EndDate")
                });
            }
            return reports;
        }
    }
}
