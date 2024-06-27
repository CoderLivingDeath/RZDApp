using rzd;
using RZDModel.Interfaces.Repositories;
using RZDModel.Interfaces.Services;
using RZDModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRepository<PlannedRoute> _routesRepository;
        private readonly IRepository<Train> _trainRepository;
        private readonly IRepository<Ticket> _ticketRepository;

        public RouteService(IRepository<PlannedRoute> routes, IRepository<Train> trainRepository, IRepository<Ticket> ticketRepository)
        {
            _routesRepository = routes;
            _trainRepository = trainRepository;
            _ticketRepository = ticketRepository;
        }

        public PlannedRoute GetById(int id)
        {
            var route = _routesRepository.Read(id);
            if (route != null) return route;
            throw new InvalidOperationException();
        }

        public IList<PlannedRoute> GetRoutes()
        {
            return _routesRepository.ReadAll();
        }

        public PlannedRoute CreateNew(int departureStationId, int arrivalStatinId, DateTime departureDate, DateTime arrivalDate, int trainId, decimal prise)
        {
            var train = _trainRepository.Read(trainId);
            if (train != null)
            {
                PlannedRoute route = new PlannedRoute()
                {
                    id = 0,
                    DepartureStation_id = departureStationId,
                    ArrivalStatin_id = arrivalStatinId,
                    DepartureDate = departureDate,
                    ArrivalDate = arrivalDate,
                    Train_id = trainId,
                    NumberOfSeats = train.Capacity,
                    NumberOfSeatsSold = 0,
                    Tickets_id = new List<int>(),
                    Price = prise
                };
                _routesRepository.Create(route);
                return route;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void UpdateNumberOfSeatsSold(int RouteId)
        {
            var route = _routesRepository.Read(RouteId);
            if (route != null)
            {
                int soldSeats = 0;
                foreach (var id in route.Tickets_id)
                {
                    var itemTicket = _ticketRepository.Read(id);
                    if (itemTicket != null)
                    {
                        if (itemTicket.SoldDate != null)
                        {
                            soldSeats++;
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }
                }

                route.NumberOfSeatsSold = soldSeats;
                _routesRepository.Update(route);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
