using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YhtTicket.CatalogApi.Queries.Stations;
using YhtTicket.Common.Infrastructure.Controllers;

namespace YhtTicket.CatalogApi.Controllers.v1
{
    public class StationsController : BaseApiController<StationsController>
    {
        [HttpGet]
        public async Task<IActionResult> GetStations()
        {
            var stations = await _mediator.Send(new GetStationsQuery());
            return Ok(stations);
        }
    }
}
