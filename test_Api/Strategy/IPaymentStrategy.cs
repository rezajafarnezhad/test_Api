namespace test_Api.Strategy;

public interface IPaymentStrategy
{
    PaymentType paymentType { get; }
    Task<string> ExecutionPayment(int amount);
}
public enum PaymentType
{
    ZarinPal = 0,
    mellet = 1,
    Meli = 2
}

public interface IPaymentFactory
{
    IPaymentStrategy GetStrategy(PaymentType paymentType);
}


public class PaymentFactory : IPaymentFactory
{
    private readonly IEnumerable<IPaymentStrategy> _strategy;
    public PaymentFactory(IEnumerable<IPaymentStrategy> strategy) { _strategy = strategy; }

    public IPaymentStrategy GetStrategy(PaymentType paymentType)
    {
        return _strategy.FirstOrDefault(c => c.paymentType == paymentType);
    }
}