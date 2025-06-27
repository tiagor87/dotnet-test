namespace DotNet.Test.Api.Shared.ValueObjects;

public interface IPaymentMethodsView : IReadOnlyCollection<string>;

public class PaymentMethods : List<string>, IPaymentMethodsView
{
    public PaymentMethods(params string[] values) : base(values)
    {
    }
    
    public IPaymentMethodsView ToView() => this;

    public static PaymentMethods Create(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return new PaymentMethods();
        }
        
        return new PaymentMethods(text.Split(',').Select(x => x.Trim()).ToArray());
    }
}