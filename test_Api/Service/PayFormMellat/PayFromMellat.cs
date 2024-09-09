using test_Api.Strategy;

namespace test_Api.Service.PayFormMellat;

public class PayFromMellat : IPaymentStrategy
{
    public PaymentType paymentType => PaymentType.mellet;
    public Task<string> ExecutionPayment(int amount)
    {
        return Task.FromResult("Mellat Payment");
    }
}