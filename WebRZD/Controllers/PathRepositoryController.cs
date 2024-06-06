using Microsoft.AspNetCore.Mvc;
using RZDModel.Data.RZD;
using RZDModel.Interfaces.Repositories;
using RZDModel.Repository;

namespace WebRZD.Controllers
{
    [Route("api/data/Path")]
    [ApiController]
    public class PathRepositoryController : ControllerBase
    {
        private readonly IRepository<RZDModel.Data.RZD.Path> _repository;
        public PathRepositoryController(IRepository<RZDModel.Data.RZD.Path> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<RZDModel.Data.RZD.Path> Get(int id)
        {
            return _repository.Read(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RZDModel.Data.RZD.Path>> GetAll()
        {
            var result = new ActionResult<IEnumerable<RZDModel.Data.RZD.Path>>(_repository.ReadAll());
            return result;
        }

        [HttpPost]
        public ActionResult<RZDModel.Data.RZD.Path> Create(RZDModel.Data.RZD.Path entity)
        {
            return _repository.Create(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RZDModel.Data.RZD.Path entity)
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
