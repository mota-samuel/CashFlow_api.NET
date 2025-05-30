using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpensesUseCase
{
    public ResponseRegisterExpensesJson Execute(RequestRegisterExpenseJson request)
    {



        return new ResponseRegisterExpensesJson()
        {
            Title = request.Title
        };
    }
}
