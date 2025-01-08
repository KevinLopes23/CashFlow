using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
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


            //Actt
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
        }


        [Fact]
        public void Error_Date_Future()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = ResquestRegisterExpenseJsonBuilder.Build();
            request.Date = DateTime.UtcNow.AddDays(1); 



            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE));
        }

        [Fact]
        public void Error_Payment_Type_Invalid()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = ResquestRegisterExpenseJsonBuilder.Build();
            request.PaymentType = (PaymentType)700;



            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-7)]
        public void Error_Amount_Invalid(decimal amount)
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = ResquestRegisterExpenseJsonBuilder.Build();
            request.Amount = amount;



            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
        }


    }
}
