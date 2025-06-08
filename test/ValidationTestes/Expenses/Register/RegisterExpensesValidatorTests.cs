using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Request;
using FluentAssertions;

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
       result.IsValid.Should().BeTrue("because all fields are valid");
    }

    [Fact]
    public void ErrorTitle_Empty()
    {
        //arrenge
        var validator = new RegisterExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;
        //act
        var result = validator.Validate(request);

        //assert
        result.IsValid.Should().BeFalse("because the title fields is empty");
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Fact]
    public void ErrorDate_InFuture()
    {
        //arrenge
        var validator = new RegisterExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(2);
        //act
        var result = validator.Validate(request);

        //assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.DATEVALUE_IN_THE_FUTURE));
    }

    [Fact]
    public void ErrorPayment_Invalid()
    {
        //arrenge
        var validator = new RegisterExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Type = (PaymentType)100;
        //act
        var result = validator.Validate(request);

        //assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_METHOD_INVALID));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-7)]
    public void ErrorAmount_Invalid(decimal amount)
    {
        //arrenge
        var validator = new RegisterExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;
        //act
        var result = validator.Validate(request);

        //assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.VALUE_GREATER_THAN_0));
    }
}

