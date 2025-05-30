using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpensesUseCase
{
    public ResponseRegisterExpensesJson Execute(RequestRegisterExpenseJson request)
    {
        ValidationOfData(request);

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
