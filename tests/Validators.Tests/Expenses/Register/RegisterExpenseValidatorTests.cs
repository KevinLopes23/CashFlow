using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.requests;
using CashFlow.Exception;
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
        [Fact]
        public void Error_Title_Empty()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = ResquestRegisterExpenseJsonBuilder.Build();
            request.Title = string.Empty;
            request.Amount = -1;


            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
        }

    }
}
