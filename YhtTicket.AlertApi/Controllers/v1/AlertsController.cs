using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YhtTicket.AlertApi.Commands.Alerts;
using YhtTicket.Common.Infrastructure.Controllers;

namespace YhtTicket.AlertApi.Controllers.v1
{
    public class AlertsController : BaseApiController<AlertsController>
    {
        [HttpPost]
        public async Task<IActionResult> CreateAlerts([FromBody] CreateAlertsCommand body)
        {
            var response = await _mediator.Send(body);
            return Ok(response);
        }
    }
}
