namespace ACME.ManagementSystem.Core.Utils
{
    public interface IPaymentValidator
    {
        void Validate(decimal amountPaid, decimal registrationFee);
    }

    public class PaymentValidator : IPaymentValidator
    {
        public void Validate(decimal amountPaid, decimal registrationFee)
        {
            if (amountPaid < registrationFee)
            {
                throw new InvalidOperationException(ErrorMessages.INSUFFICIENT_PAYMENT);
            }
        }
    }
}
