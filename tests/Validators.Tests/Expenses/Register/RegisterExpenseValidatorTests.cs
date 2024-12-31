using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.requests;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = new ResquestRegisterExpenseJson
            {
                Amount = 100,
                Date = DateTime.Now.AddDays(-1),
                Description = "Description",
                Title = "" +
                "",
                PaymentType = CashFlow.Communication.Enums.PaymentType.CreditCard
            };

            //Act
            var result = validator.Validate(request);

            //Assert
            Assert.True(result.IsValid);

        }

    }
}
