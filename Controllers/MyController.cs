

using System;
using Microsoft.AspNetCore.Mvc;
using Sentry;

namespace Dotnet.With.Sentry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            SentrySdk.CaptureMessage("Something went wrong");

            // Transaction can be started by providing, at minimum, the name and the operation
            var transaction = SentrySdk.StartTransaction(
                "test-transaction-name",
                "test-transaction-operation"
            );
            // Transactions can have child spans (and those spans can have child spans as well)
            var span = transaction.StartChild("test-child-operation");

            // ...
            // (Perform the operation represented by the span/transaction)
            // ...

            span.Finish(); // Mark the span as finished
            transaction.Finish(); // Mark the transaction as finished and send it to Sentry
            try
            {
                throw null;
            }
            catch(Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
            return Ok();
        }
    }
}