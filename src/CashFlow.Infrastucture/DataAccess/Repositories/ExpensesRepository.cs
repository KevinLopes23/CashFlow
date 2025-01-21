using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastucture.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepositorie
    {

        private readonly CashFlowDbContext _dbContext;

        public ExpensesRepository(CashFlowDbContext dbContext)
        {
            
        }

        public void Add(Expense expense)
        {
            var dbContext = new CashFlowDbContext();

            _dbContext.Expenses.Add(expense);

            _dbContext.SaveChanges();
        }
    }
}
