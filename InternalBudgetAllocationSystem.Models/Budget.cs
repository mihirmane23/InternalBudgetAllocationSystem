namespace InternalBudgetAllocationSystem.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string BudgetName { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public string Status { get; set;  }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}
