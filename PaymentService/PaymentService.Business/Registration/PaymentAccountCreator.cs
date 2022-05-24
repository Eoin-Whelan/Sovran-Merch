using PaymentService.Model.Accounts;
using Sovran.Logger;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Business
{
    /// <summary>
    /// PaymentAccountCreator acts as the handler class for 
    /// all Stripe Connect account generation. Currently,
    /// this class generates a single onboarding link that allows for
    /// users to register themselves with the platform and begin taking payments
    /// associated with the Sovran Merch platform.
    /// </summary>
    /// <seealso cref="PaymentService.Business.IPaymentAccountCreator" />
    public class PaymentAccountCreator : IPaymentAccountCreator
    {
        private readonly ISovranLogger _logger;
        public PaymentAccountCreator(ISovranLogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// CreateAccount generates a Stripe Express account to associate with a merchant in the process
        /// of registering for an account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PaymentRegistrationResponse CreateAccount(PaymentRegistrationRequest request)
        {
            try
            {
                _logger.LogActivity("Initiating registration flow.");
                var accountOptions = new AccountCreateOptions
                {
                    Type = "standard",
                    Country = "IE",
                    Email = request.EmailAddress,
                    BusinessType = "individual"
                };

                var accountService = new AccountService();
                var result = accountService.Create(accountOptions);

                /*
                 * Currently, no redirect as front-end is not deployed.
                 */
                var options = new AccountLinkCreateOptions
                {
                    Account = result.Id,
                    RefreshUrl = "https://example.com/reauth",
                    ReturnUrl = "https://example.com/return",
                    Type = "account_onboarding",
                };
                var service = new AccountLinkService();
                var newAccount = service.Create(options);

                PaymentRegistrationResponse response = new PaymentRegistrationResponse
                {
                    OnboardingUrl = newAccount.Url,
                    StripeAccountNo = result.Id
                };
                _logger.LogActivity("Flow complete. Returning onboarding url.");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered during registration flow: " + ex.Message);
                return null;
            }

        }
    }
}
