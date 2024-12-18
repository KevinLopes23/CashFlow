using CashFlow.Communication.Enums;
using CashFlow.Communication.requests;
using CashFlow.Exception.ExpectionsBase;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResquestRegisterExpenseJson Execute(ResquestRegisterExpenseJson resquest)
    {
        Validate(resquest);

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
