using Microsoft.AspNetCore.Mvc;
using RZDModel.Data.RZD;
using RZDModel.Interfaces.Repositories;
using RZDModel.Repository;

namespace WebRZD.Controllers
{
    [Route("api/data/Destination")]
    [ApiController]
    public class DestinationRepositoryController : ControllerBase
    {
        private readonly IRepository<Destination> _repository;

        public DestinationRepositoryController(IRepository<Destination> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Destination> Get(int id)
        {
            return _repository.Read(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Destination>> GetAll()
        {
            var result = new ActionResult<IEnumerable<Destination>>(_repository.ReadAll());
            return result;
        }

        [HttpPost]
        public ActionResult<Destination> Create(Destination entity)
        {
            return _repository.Create(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Destination entity)
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
