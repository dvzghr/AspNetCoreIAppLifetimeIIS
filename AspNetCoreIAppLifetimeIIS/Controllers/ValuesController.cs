using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreIAppLifetimeIIS.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> logger;

        public ValuesController(IApplicationLifetime lifetime, ILogger<ValuesController> logger)
        {
            this.logger = logger;

            lifetime.ApplicationStarted.Register(() => OnAppEvent("*** STARTED! ***"));
            lifetime.ApplicationStopping.Register(() => OnAppEvent("*** STOPPING.... ***"));
            lifetime.ApplicationStopped.Register(() => OnAppEvent("*** STOPPED!!! ***"));
        }

        private void OnAppEvent(string msg)
        {
            logger.LogWarning(msg);
            System.Threading.Thread.Sleep(3000);
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "DONE!";
        }
    }
}
