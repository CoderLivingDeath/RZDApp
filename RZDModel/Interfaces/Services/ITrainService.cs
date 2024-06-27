using rzd;

namespace RZDModel.Interfaces.Services
{
    public interface ITrainService
    {
        Train CreateNew(int capacity);
        Train GetById(int id);

        IEnumerable<Train> GetAll();
    }
}