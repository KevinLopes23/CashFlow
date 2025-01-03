using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.requests;
using CommonTestUtilites.Requets;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = ResquestRegisterExpenseJsonBuilder.Build();


            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();

        }

    }
}
