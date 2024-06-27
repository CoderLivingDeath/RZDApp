using rzd;
using RZDModel.Interfaces.Repositories;
using RZDModel.Interfaces.Services;

namespace RZDModel.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<BankAccount> _bankAccountRepository;
        private readonly IRepository<PlannedRoute> _plannedRouteRepository;
        private readonly IPaymentService _paymentService;

        public TicketService(IRepository<Ticket> ticketRepository, IPaymentService paymentService, IRepository<PlannedRoute> plannedRouteRepository, IRepository<BankAccount> bankAccountRepository, IRepository<User> userRepository)
        {
            _ticketRepository = ticketRepository;
            _paymentService = paymentService;
            _plannedRouteRepository = plannedRouteRepository;
            _bankAccountRepository = bankAccountRepository;
            _userRepository = userRepository;
        }

        public Ticket GetById(int id)
        {
            var ticket = _ticketRepository.Read(id);
            if (ticket != null) return ticket;
            throw new InvalidOperationException();
        }

        public Ticket CreateNew(int plannedRouteId)
        {
            var Route = _plannedRouteRepository.Read(plannedRouteId);
            if (Route != null)
            {
                Ticket ticket = new Ticket()
                {
                    id = 0,
                    User_id = null,
                    PlannedRoute_id = plannedRouteId,
                    SoldDate = null,
                    Price = Route.Price,
                };

                _ticketRepository.Create(ticket);

                Route.Tickets_id.Add(ticket.id);
                _plannedRouteRepository.Update(Route);

                return ticket;
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public void PayForTicket(int ticketId, int userId)
        {
            var ticket = _ticketRepository.Read(ticketId);
            var user = _userRepository.Read(userId);

            if (ticket != null && user != null && user.BankAccount_id != null && ticket.SoldDate == null)
            {
                var bankAccount = _bankAccountRepository.Read((int)user.BankAccount_id);
                var route = _plannedRouteRepository.Read(ticket.PlannedRoute_id);
                if (bankAccount != null && route != null)
                {
                    var IsPayed = _paymentService.PayByCard(bankAccount.CardNumber, ticket.Price);

                    if (IsPayed)
                    {
                        ticket.User_id = userId;
                        ticket.SoldDate = DateTime.Now;

                        _ticketRepository.Update(ticket);
                        route.NumberOfSeatsSold += 1;
                        _plannedRouteRepository.Update(route);

                        return;
                    }
                }
            }

            throw new InvalidOperationException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _ticketRepository.ReadAll();
        }
    }
}
