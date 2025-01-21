using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]

        public ActionResult Register(
        
            [FromServices] IRegisterExpenseUseCase useCase,
            [FromBody] ResquestRegisterExpenseJson request)
        { 
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

    }
}
