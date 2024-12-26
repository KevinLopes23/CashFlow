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

        public ActionResult Register([FromBody] ResquestRegisterExpenseJson resquest)
        {
            var useCase = new RegisterExpenseUseCase();
            var response = useCase.Execute(resquest);
            return Created(string.Empty, response);
        }

    }
}
