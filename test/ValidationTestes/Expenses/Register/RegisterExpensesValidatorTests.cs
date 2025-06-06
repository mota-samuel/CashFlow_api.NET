using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CommonTestUtilities.Request;

namespace ValidationTestes.Expenses.Register;
public class RegisterExpensesValidatorTests
{

    [Fact]
    public void success()
    {
        //arrenge
        var validator = new RegisterExpensesValidator();
        var request =  RequestRegisterExpenseJsonBuilder.Build();

        //act
        var result = validator.Validate(request);

       //assert
       Assert.True(result.IsValid);
    }
}

