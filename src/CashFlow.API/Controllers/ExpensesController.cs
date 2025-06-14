﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody]RequestRegisterExpenseJson request)
    {
        var useCase = new RegisterExpensesUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty,response);
    }
}
