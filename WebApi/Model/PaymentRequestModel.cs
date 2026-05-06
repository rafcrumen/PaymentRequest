using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    [Table("PaymentRequest")]
    public class PaymentRequestModel
    {
        public int Id {  get; set; }
        public required string RequesterName { get; set; }
        public required decimal Amount { get; set; }
        public required string Currency {  get; set; }
        public  DateTime CreatedAt { get; set; }
        public string? Description { get; set; }

    }
}
