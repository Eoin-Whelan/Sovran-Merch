using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Model.Accounts
{
    /// <summary>
    /// Registration request for onboarding URL generation.
    /// </summary>
    public class PaymentRegistrationRequest
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// A single, required e-mail is needed for onboarding.
        /// </value>
        [Required(ErrorMessage = "Missing Info : EmailAddress")]
        public string EmailAddress { get; set; }
    }
}
