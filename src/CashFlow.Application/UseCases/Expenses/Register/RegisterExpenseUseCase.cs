using CashFlow.Communication.requests;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExpectionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResquestRegisterExpenseJson Execute(ResquestRegisterExpenseJson resquest)
    {
        Validate(resquest);

        var entity = new Expense
        {
            Amount = resquest.Amount,
            Date = resquest.Date,
            Description = resquest.Description,
            Title = resquest.Title,
            PaymentType = (Domain.Enums.PaymentType)resquest.PaymentType
        };

        return new ResquestRegisterExpenseJson();
    }

    private void Validate(ResquestRegisterExpenseJson resquest)
    {
        var validator  = new RegisterExpenseValidator();

       var result =  validator.Validate(resquest);

       if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationExpection(errorMessages);
        }

    }
}
