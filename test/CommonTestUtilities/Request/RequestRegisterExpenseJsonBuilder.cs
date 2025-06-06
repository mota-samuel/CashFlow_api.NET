using Bogus;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Request;
public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(x => x.Title, f => f.Commerce.ProductName())
            .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
            .RuleFor(x => x.Date, f => f.Date.Past(1))
            .RuleFor(x => x.Amount, f => f.Finance.Amount(10, 1000, 2))
            .RuleFor(x => x.Type, f => f.PickRandom<CashFlow.Communication.Enums.PaymentType>());
  
    }
}
