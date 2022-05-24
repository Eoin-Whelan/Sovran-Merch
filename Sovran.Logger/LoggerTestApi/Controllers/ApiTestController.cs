using Microsoft.AspNetCore.Mvc;
using Sovran.Logger;
using System.Text.Json;

namespace LoggerTestApi.Controllers
{
    /// <summary>
    /// Rudimentary controller for testing Sovran Logger service.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class ApiTestController : ControllerBase
    {

        private readonly ISovranLogger _logger;

        public ApiTestController(ISovranLogger logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "SampleMongoPayload")]
        public IActionResult PostToMongo([FromBody] TestPayload payload)
        {
            _logger.LogPayload(payload);
            _logger.LogActivity("Here is a test message!");
            return Ok("Payload saved");
        }
    }

    public class TestPayload
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}