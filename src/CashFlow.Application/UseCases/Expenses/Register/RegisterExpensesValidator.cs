using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpensesValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpensesValidator()
    {
        RuleFor(request => request.Title).NotEmpty().WithMessage("The Title is required.");
        RuleFor(request => request.Amount).GreaterThan(0).WithMessage("The amount value must be greaater than 0");
        RuleFor(request => request.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The date can't be in the future");
        RuleFor(request => request.Type).IsInEnum().WithMessage("Payment Type doesnt exist");
        
    }
}
