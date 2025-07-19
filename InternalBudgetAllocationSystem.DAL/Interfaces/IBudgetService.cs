using InternalBudgetAllocationSystem.Models;

namespace InternalBudgetAllocationSystem.DAL.Interfaces
{
    public interface IBudgetService
    {
        Task<Budget> GetByIdAsync(int id);

        Task<List<Budget>> GetAllAsync();

        Task CreateAsync(Budget budget);

        Task UpdateAsync(Budget budget);

        Task DeleteAsync(int id);
    }
}
