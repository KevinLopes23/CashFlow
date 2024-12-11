using CashFlow.Communication.Enums;
using CashFlow.Communication.requests;

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
        var titleIsEmpty = string.IsNullOrWhiteSpace(resquest.Title);

        if (titleIsEmpty)
        {
            throw new ArgumentException("The title is required");
        }

        if (resquest.Amount <= 0)
        {
            throw new ArgumentException("The Amount must be greater than zero ");
        }


        var result = DateTime.Compare(resquest.Date, DateTime.UtcNow);
        if (result > 0)
        {
            throw new ArgumentException("Expenses cannot be for the future");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), resquest.PaymentType);

        if (paymentTypeIsValid == false)
        {
            throw new ArgumentException("Payment type is not valid");
        }
    }
}
