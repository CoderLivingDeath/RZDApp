using rzd;

namespace RZDModel.Interfaces.Services
{
    public interface IRouteService
    {
        PlannedRoute CreateNew(int departureStationId, int arrivalStatinId, DateTime departureDate, DateTime arrivalDate, int trainId, decimal prise);
        PlannedRoute GetById(int id);
        IList<PlannedRoute> GetRoutes();
        void UpdateNumberOfSeatsSold(int RouteId);
    }
}