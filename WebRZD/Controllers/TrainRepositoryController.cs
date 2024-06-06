using Microsoft.AspNetCore.Mvc;
using RZDModel.Data.RZD;
using RZDModel.Interfaces.Repositories;
using RZDModel.Repository;

namespace WebRZD.Controllers
{
    [Route("api/data/Train")]
    [ApiController]
    public class TrainRepositoryController : ControllerBase
    {
        private readonly IRepository<Train> _repository;
        public TrainRepositoryController(IRepository<Train> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Train> Get(int id)
        {
            return _repository.Read(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Train>> GetAll()
        {
            var result = new ActionResult<IEnumerable<Train>>(_repository.ReadAll());
            return result;
        }

        [HttpPost]
        public ActionResult<Train> Create(Train entity)
        {
            return _repository.Create(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Train entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _repository.Update(entity);
            return NoContent();
        }
    }
}
