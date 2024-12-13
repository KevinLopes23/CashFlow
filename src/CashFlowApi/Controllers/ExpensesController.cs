using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.requests;
using CashFlow.Communication.Responses;
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
            try
            {
                var useCase = new RegisterExpenseUseCase();
                var response = useCase.Execute(resquest);
                return Created(string.Empty, response);
            }
            catch(ArgumentException ex) 
            {
                var errorResponse = new ResponseErrorJson(ex.Message);
                return BadRequest(errorResponse);
            }

            catch 
            {
                var errorResponse = new ResponseErrorJson("unknown error");
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

    }
}
