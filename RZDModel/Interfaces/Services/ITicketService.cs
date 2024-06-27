using rzd;

namespace RZDModel.Interfaces.Services
{
    public interface ITicketService
    {
        Ticket CreateNew(int plannedRouteId);
        Ticket GetById(int id);
        IEnumerable<Ticket> GetAll();
        void PayForTicket(int ticketId, int userId);
    }
}