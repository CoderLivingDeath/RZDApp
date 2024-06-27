using rzd;
using RZDModel.Interfaces.Repositories;
using RZDModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Services
{
    public class TrainService : ITrainService
    {
        private readonly IRepository<Train> _trainRepository;

        public TrainService(IRepository<Train> trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public Train GetById(int id)
        {
            var train = _trainRepository.Read(id);
            if (train != null) return train;

            throw new InvalidOperationException();
        }

        public IEnumerable<Train> GetAll()
        {
            return _trainRepository.ReadAll();
        }

        public Train CreateNew(int capacity)
        {
            Train train = new Train()
            {
                id = 0,
                Capacity = capacity
            };

            _trainRepository.Create(train);

            return train;
        }
    }
}
