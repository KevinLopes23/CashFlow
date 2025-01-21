using CashFlow.Communication.requests;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public  interface IRegisterExpenseUseCase
    {
        public ResquestRegisterExpenseJson Execute(ResquestRegisterExpenseJson resquest);
    }
}
