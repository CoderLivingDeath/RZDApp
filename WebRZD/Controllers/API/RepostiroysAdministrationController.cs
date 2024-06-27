using Microsoft.AspNetCore.Mvc;
using RZDModel.Interfaces.Services;

namespace WebRZD.Controllers.API
{
    [Route("api")]
    [ApiController]
    public class RepostiroysAdministrationController : ControllerBase
    {
        private readonly IRouteService routeService;
        private readonly IUserService userService;
        private readonly ITicketService ticketService;
        private readonly ITrainService trainService;
        private readonly IStationService stationService;
        public RepostiroysAdministrationController(IRouteService routeService, IUserService userService, ITicketService ticketService, ITrainService trainService, IStationService stationService)
        {
            this.routeService = routeService;
            this.userService = userService;
            this.ticketService = ticketService;
            this.trainService = trainService;
            this.stationService = stationService;
        }

        [HttpPost("Ticket")]
        public IActionResult Ticket(int plannedRouteId)
        {
            ticketService.CreateNew(plannedRouteId);

            return Ok();
        }

        [HttpPost("Station")]
        public IActionResult Station(string title)
        {
            stationService.Create(title);

            return Ok();
        }

        [HttpPost("Train")]
        public IActionResult Train(int capacity)
        {
            trainService.CreateNew(capacity);

            return Ok();
        }

        [HttpPost("Úser")]
        public IActionResult User(string fullname)
        {
            userService.CreateNewUser(fullname, "user");

            return Ok();
        }

        [HttpPost("Route")]
        public IActionResult Route(int departureStationId, int arrivalStationId, DateTime DepartureTime, DateTime ArrivalTime, int trainId, decimal prise)
        {
            routeService.CreateNew(departureStationId, arrivalStationId, DepartureTime, ArrivalTime, trainId, prise);

            return Ok();
        }
    }
}
