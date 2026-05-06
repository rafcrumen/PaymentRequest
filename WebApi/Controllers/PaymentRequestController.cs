using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PaymentRequestController : ControllerBase
    {
        private readonly IPaymentRequestRepository _repository;

        public PaymentRequestController(IPaymentRequestRepository repository)
        {
            _repository = repository;
        }

        // POST: api/payments
        [HttpPost]
        public async Task<ActionResult<PaymentRequestModel>> PostPaymentRequest(PaymentRequestModel request)
        {
            var created = await _repository.PostPaymentRequest(request);
            return CreatedAtAction(nameof(GetPaymentRequestById), new { id = created.Id }, created);
        }

        // GET: api/payments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentRequestModel>> GetPaymentRequestById(int id)
        {
            var payment = await _repository.GetPaymentRequest(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // GET: api/payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentRequestModel>>> GetAllPaymentRequests()
        {
            var payments = await _repository.GetAllPaymentRequests();
            return Ok(payments);
        }
    }
}