using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastucture.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {
        public CashFlowDbContext()
        {
        }

        public CashFlowDbContext(DbContextOptions options) : base(options) 
        {
            
        }


        public DbSet<Expense> Expenses { get; set; }

       
    }
}
