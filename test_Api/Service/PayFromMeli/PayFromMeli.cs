using test_Api.Strategy;

namespace test_Api.Service.PayFromMeli;

public class PayFromMeli : IPaymentStrategy
{
    public PaymentType paymentType => PaymentType.Meli;
    public Task<string> ExecutionPayment(int amount)
    {
        return Task.FromResult("Meli payment");
    }
}