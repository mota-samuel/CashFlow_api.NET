using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpensesUseCase : IRegisterExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    public RegisterExpensesUseCase(IExpensesRepository repository)
    {
        _repository = repository;
    }
    public ResponseRegisterExpensesJson Execute(RequestRegisterExpenseJson request)
    {
        ValidationOfData(request);
               
        var entity = new Expense
        {
            Title = request.Title,
            Description = request.Description,
            Date = request.Date,
            Amount = request.Amount,
            Payment_Type = (Domain.Enum.PaymentType)request.Type
        };

        _repository.add(entity);

        return new ResponseRegisterExpensesJson()
        {
            Title = request.Title
        };
    }

    private void ValidationOfData(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpensesValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
             var errorMessage = result.Errors.Select(errors => errors.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessage);
        }
    }

}
