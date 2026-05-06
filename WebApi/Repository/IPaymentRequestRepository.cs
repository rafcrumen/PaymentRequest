using WebApi.Model;

namespace WebApi.Repository
{
    public interface IPaymentRequestRepository
    {
        public Task<List<PaymentRequestModel>> GetAllPaymentRequests();
        public Task<PaymentRequestModel?> GetPaymentRequest(int id);
        public Task<PaymentRequestModel> PostPaymentRequest(PaymentRequestModel request);
    }
}
