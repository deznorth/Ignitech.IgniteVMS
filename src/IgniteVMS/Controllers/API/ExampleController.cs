using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IgniteVMS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : Controller
    {
        private readonly ILogger<ExampleController> logger;

        public ExampleController(
            ILogger<ExampleController> logger
        )
        {
            this.logger = logger;
        }

        /// <summary>
        /// This is an example endpoint
        /// </summary>
        /// <returns>A hello world string</returns>
        [HttpGet]
        public async Task<IActionResult> GetSomeResult()
        {
            try
            {
                return Ok("Hello World!");
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
