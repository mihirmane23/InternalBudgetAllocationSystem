using InternalBudgetAllocationSystem.DAL.Interfaces;
using InternalBudgetAllocationSystem.Models;
using Npgsql;
using System.Data;

namespace InternalBudgetAllocationSystem.DAL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly string _connectionString;

        public DepartmentService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("SELECT * FROM Departments WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("Id", id);
            
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Department
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Manager = reader.GetString("Manager"),
                    Location = reader.GetString("Location"),
                    ContactEmail = reader.GetString("ContactEmail"),
                    PhoneNumber = reader.GetString("PhoneNumber")
                };
            }
            return null;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            var departments = new List<Department>();
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            
            using var command = new NpgsqlCommand("SELECT * FROM Departments", connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                departments.Add(new Department
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Manager = reader.GetString("Manager"),
                    Location = reader.GetString("Location"),
                    ContactEmail = reader.GetString("ContactEmail"),
                    PhoneNumber = reader.GetString("PhoneNumber")
                });
            }
            return departments;
        }
    }
}
