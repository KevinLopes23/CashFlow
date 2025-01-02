using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.requests;

namespace CommonTestUtilites.Requets
{
    public class ResquestRegisterExpenseJsonBuilder
    {
        public ResquestRegisterExpenseJson Build()
        {
            return new Faker<ResquestRegisterExpenseJson>()
                  .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
                  .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
                  .RuleFor(r => r.Date, faker => faker.Date.Past())
                  .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
                  .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
        }
    }
}
