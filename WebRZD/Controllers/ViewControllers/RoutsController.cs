using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using rzd;
using RZDModel.Interfaces.Services;
using System.Security.Claims;
using WebRZD.Models.RoutsModel;

namespace WebRZD.Controllers.ViewControllers
{

    [Route("Routs")]
    public class RoutsController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly IStationService _stationService;
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public RoutsController(IRouteService routeService, IStationService stationService, ITicketService ticketService, IUserService userService)
        {
            _routeService = routeService;
            _stationService = stationService;
            _ticketService = ticketService;
            _userService = userService;
        }

        [HttpGet("List")]
        public IActionResult Routs()
        {
            IEnumerable<RouteForm> routs = _routeService.GetRoutes().Select(route =>
            {
                bool allSold = true;
                if (route.NumberOfSeats > route.NumberOfSeatsSold)
                {
                    allSold = false;
                }
                Station departureStation = _stationService.GetById(route.DepartureStation_id);
                Station ArrivalStation = _stationService.GetById(route.ArrivalStatin_id);

                return new RouteForm() { Id = route.id, From = departureStation.Title, To = ArrivalStation.Title, DepartureTime = route.DepartureDate, ArrivalTime = route.ArrivalDate, Price = route.Price, IsAllSold = allSold };
            });

            ViewBag.Routes = routs;
            return View();
        }

        [HttpGet("PayTicket/{routeId}")]
        public IActionResult PayTicket(int routeId)
        {
            var route = _routeService.GetById(routeId);

            bool allSold = true;
            if (route.NumberOfSeats > route.NumberOfSeatsSold)
            {
                allSold = false;
            }

            Station departureStation = _stationService.GetById(route.DepartureStation_id);
            Station ArrivalStation = _stationService.GetById(route.ArrivalStatin_id);
            var form = new RouteForm { Id = route.id, From = departureStation.Title, To = ArrivalStation.Title, DepartureTime = route.DepartureDate, ArrivalTime = route.ArrivalDate, Price = route.Price, IsAllSold = allSold };
            ViewBag.Route = form;
            return View();
        }
        [Authorize]
        [HttpPost("PayTicket/{routeId}")]
        public IActionResult PayTicketPost(int routeId)
        {
            var route = _routeService.GetById(routeId);
            var ticket = _ticketService.GetAll().Where(t => t.SoldDate == null).FirstOrDefault();

            if (ticket != null)
            {
                string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
                User user = _userService.GetById(int.Parse(userId));
                if (user.BankAccount_id != null)
                {
                    _ticketService.PayForTicket(ticket.id, user.id);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            return Redirect(Url.Action(controller: "Index", action: "Index"));
        }
    }
}
