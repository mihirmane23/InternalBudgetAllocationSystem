using InternalBudgetAllocationSystem.Models;

namespace InternalBudgetAllocationSystem.DAL.Interfaces
{
    public interface IReportService
    {
        Task<List<BudgetReport>> GetBudgetReportsAsync();
    }
}
