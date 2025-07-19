using InternalBudgetAllocationSystem.Models;

namespace InternalBudgetAllocationSystem.DAL.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> GetByIdAsync(int id);

        Task<List<Department>> GetAllAsync();
    }
}
