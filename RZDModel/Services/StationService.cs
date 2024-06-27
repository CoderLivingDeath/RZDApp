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
    public class StationService : IStationService
    {
        private readonly IRepository<Station> _stationRepository;

        public StationService(IRepository<Station> stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public Station GetById(int id)
        {
            var station = _stationRepository.Read(id);
            if (station != null) return station;
            throw new InvalidOperationException();
        }

        public IEnumerable<Station> GetAll()
        {
            return _stationRepository.ReadAll();
        }

        public Station Create(string StationTitle)
        {
            Station station = new Station()
            {
                id = 0,
                Title = StationTitle,
            };

            _stationRepository.Create(station);
            return station;
        }
    }
}
