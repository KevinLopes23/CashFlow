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
            return Created();
        }

    }
}
