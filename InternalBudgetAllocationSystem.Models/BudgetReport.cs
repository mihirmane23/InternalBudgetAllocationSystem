namespace InternalBudgetAllocationSystem.Models
{
    public class BudgetReport
    {
        public int BudgetId { get; set; }

        public string BudgetName { get; set; }

        public string DepartmentName { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
