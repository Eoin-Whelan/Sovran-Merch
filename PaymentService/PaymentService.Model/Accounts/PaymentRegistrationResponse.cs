using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Model.Accounts
{
    /// <summary>
    /// Response class intended to return the Stripe onboarding URL and account number.
    /// </summary>
    public class PaymentRegistrationResponse
    {
        public string? OnboardingUrl { get; set; }
        public string? StripeAccountNo { get; set; }
    }
}
