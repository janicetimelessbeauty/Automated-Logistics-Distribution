using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeSystemAPI.Models.DTOClient;
using TradeSystemAPI.Repository;

namespace TradeSystemAPI.Controllers
{
    [Route("api/delivery")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        private readonly GraphInterface _graphInterface;

        public GraphController(GraphInterface graphInterface)
        {
            _graphInterface = graphInterface;
        }
        [HttpPost]
        public IActionResult getDelivery(Distance distance)
        {
            List<string> route = _graphInterface.paths(distance.distance);
            return Ok(route);
        }
    }
}
