using Microsoft.AspNetCore.Mvc;
using RZDModel.Data.Payment;
using RZDModel.Interfaces.Repositories;
using RZDModel.Repository;

namespace WebRZD.Controllers
{
    [Route("api/data/PaymentData")]
    [ApiController]
    public class PaymentDataRepositoryController : ControllerBase
    {
        private readonly IRepository<PaymentData> _repository;
        public PaymentDataRepositoryController(IRepository<PaymentData> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentData> Get(int id)
        {
            return _repository.Read(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentData>> GetAll()
        {
            var result = new ActionResult<IEnumerable<PaymentData>>(_repository.ReadAll());
            return result;
        }

        [HttpPost]
        public ActionResult<PaymentData> Create(PaymentData entity)
        {
            return _repository.Create(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PaymentData entity)
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
