using Microsoft.AspNetCore.Mvc;
using RZDModel.Data.Payment;
using RZDModel.Data.RZD;
using RZDModel.Interfaces.Repositories;
using RZDModel.Repository;

namespace WebRZD.Controllers
{
    [Route("api/data/PlannedRoute")]
    [ApiController]
    public class PlannedRouteRepositoryController : ControllerBase
    {
        private readonly IRepository<PlannedRoute> _repository;
        public PlannedRouteRepositoryController(IRepository<PlannedRoute> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<PlannedRoute> Get(int id)
        {
            return _repository.Read(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlannedRoute>> GetAll()
        {
            var result = new ActionResult<IEnumerable<PlannedRoute>>(_repository.ReadAll());
            return result;
        }

        [HttpPost]
        public ActionResult<PlannedRoute> Create(PlannedRoute entity)
        {
            return _repository.Create(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PlannedRoute entity)
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
