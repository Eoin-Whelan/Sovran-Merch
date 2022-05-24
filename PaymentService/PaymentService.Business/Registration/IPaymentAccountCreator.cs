using PaymentService.Model.Accounts;

namespace PaymentService.Business
{
    /// <summary>
    /// Primary contract for PaymentAccountCreator. Used in Dependency Injection.
    /// </summary>
    public interface IPaymentAccountCreator
    {
        public PaymentRegistrationResponse CreateAccount(PaymentRegistrationRequest email);
    }
}
