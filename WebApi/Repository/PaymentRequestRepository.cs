using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Repository
{
    public class PaymentRequestRepository : IPaymentRequestRepository
    {
        private readonly DataContext _context;
        public PaymentRequestRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<PaymentRequestModel>> GetAllPaymentRequests()
        {
            var result = await this._context.PaymentRequests.ToListAsync();
            return result;
        }

        public async Task<PaymentRequestModel?> GetPaymentRequest(int id)
        {
            var result = await this._context.PaymentRequests.FindAsync(id);
            return result;
        }

        public async Task<PaymentRequestModel> PostPaymentRequest(PaymentRequestModel request)
        {
            this._context.PaymentRequests.Add(request);
            await  this._context.SaveChangesAsync();
            return request;
        }
    }
}
