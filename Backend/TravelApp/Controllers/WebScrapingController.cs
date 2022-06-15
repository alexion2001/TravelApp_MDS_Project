using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Application.Features.WebScraping;

namespace TravelApp.Controllers
{
    public class WebScrapingController : BaseApplicationController
    {
        [HttpPost("webscraping")]
        public async Task<IActionResult> webScraping([FromBody] WebScrapingCommand webScrapingCommand)
        {
            try
            {
                var result = await Mediator.Send(webScrapingCommand);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
