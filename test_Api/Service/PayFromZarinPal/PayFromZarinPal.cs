using test_Api.Strategy;

namespace test_Api.Service.PayFromZarinPal
{
    public class PayFromZarinPal : IPaymentStrategy
    {
        public PaymentType paymentType => PaymentType.ZarinPal;
        public Task<string> ExecutionPayment(int amount)
        {
            return Task.FromResult("ZarinPal Payment");
        }
    }
}
