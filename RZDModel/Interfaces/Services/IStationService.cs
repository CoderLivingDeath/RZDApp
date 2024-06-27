using rzd;

namespace RZDModel.Interfaces.Services
{
    public interface IStationService
    {
        Station Create(string StationTitle);
        IEnumerable<Station> GetAll();
        Station GetById(int id);
    }
}