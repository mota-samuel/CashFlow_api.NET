using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;

namespace ValidationTestes.Expenses.Register;
public class RegisterExpensesValidatorTests
{
    [Fact]
    public void success()
    {
        //arrenge
        var validator = new RegisterExpensesValidator();
        var request = new RequestRegisterExpenseJson
        {
            Title = "Test",
            Amount = 100,
            Description = "Test description",
            Date = DateTime.Now.AddDays(-2),
            Type = CashFlow.Communication.Enums.PaymentType.EletronicTransfer
        };
        //act
        var result = validator.Validate(request);

       //assert
       Assert.True(result.IsValid);
    }
}

