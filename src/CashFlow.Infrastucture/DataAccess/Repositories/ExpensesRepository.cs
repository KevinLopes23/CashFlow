using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastucture.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepositorie
    {
        public void Add(Expense expense)
        {
            var dbContext = new CashFlowDbContext();

            dbContext.Expenses.Add(expense);

            dbContext.SaveChanges();
        }
    }
}
