using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YhtTicket.CatalogApi.Queries.Schedules;
using YhtTicket.Common.Infrastructure.Controllers;

namespace YhtTicket.CatalogApi.Controllers.v1
{
    public class SchedulesController : BaseApiController<SchedulesController>
    {
        [HttpGet]
        public async Task<IActionResult> GetStations([FromQuery] GetSchedulesQuery query)
        {
            var schedules = await _mediator.Send(query);
            return Ok(schedules);
        }
    }
}
