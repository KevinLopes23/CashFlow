using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExpectionsBase;
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
            catch(ErrorOnValidationExpection ex) 
            {
                var errorResponse = new ResponseErrorJson(ex.Errors);
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
