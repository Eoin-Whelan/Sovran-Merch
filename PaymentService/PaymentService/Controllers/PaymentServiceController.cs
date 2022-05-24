using Microsoft.AspNetCore.Mvc;
using PaymentService.Business;
using PaymentService.Model.Accounts;
using PaymentService.Model.Payment;
using Sovran.Logger;
using Stripe;

namespace PaymentService.Controllers
{
    /// <summary>
    /// Primary controller for Payment Service. Current implementation allows:
    /// - Stripe onboarding URL generation (Registration flow)
    /// - Mock payment made to existing, verified Stripe test account.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PaymentServiceController : ControllerBase
    {
        private readonly ISovranLogger _logger;
        private readonly IPaymentAccountCreator _accountCreator;

        /// <summary>
        /// Primary constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="accountCreator"></param>
        public PaymentServiceController(ISovranLogger logger, IPaymentAccountCreator accountCreator)
        {
            _logger = logger;
            _accountCreator = accountCreator;
        }

        /// <summary>
        /// API called during registration flow. Generates a Stripe onboarding URL.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("RegisterAccount")]
        [HttpPost]
        public ActionResult<PaymentRegistrationResponse> RegisterAccount([FromBody] PaymentRegistrationRequest request)
        {
            try
            {
                _logger.LogActivity($"Payment beginning");

                PaymentRegistrationResponse validatorResponse = _accountCreator.CreateAccount(request);
                if(validatorResponse == null)
                {
                    throw new Exception("Internal Error has occurred. Please contact system administrator.");
                }
                return Ok(validatorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Payment validation threw an exception : " +  ex);

                JsonResult result = new JsonResult("Error:" + ex.Message);
                return (result);
            }
        }

        /// <summary>
        /// CreateIntent generates a Stripe payment intent for a passed Stripe account using the designated amount.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("CreateIntent")]
        [HttpPost]
        public IActionResult CreateIntent([FromBody] PaymentIntentCreateRequest request)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = request.amount,
                Currency = "eur",
                PaymentMethodTypes = new List<string>
              {
                "card",
              },
                TransferData = new PaymentIntentTransferDataOptions
                {
                    Destination = request.accId
                },
                ApplicationFeeAmount = 100
            };
            var service = new PaymentIntentService();
            var intent = service.Create(options);
            return new JsonResult(new { clientSecret = intent.ClientSecret });
        }
    }
}