using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpensesValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpensesValidator()
    {
        RuleFor(request => request.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(request => request.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.VALUE_GREATER_THAN_0);
        RuleFor(request => request.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATEVALUE_IN_THE_FUTURE);
        RuleFor(request => request.Type).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_METHOD_INVALID);
        
    }
}
