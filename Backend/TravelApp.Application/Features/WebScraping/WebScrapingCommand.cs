using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Application.ViewModels.External.SomethingWrapper;

namespace TravelApp.Application.Features.WebScraping
{
    public class WebScrapingCommand : IRequest<List<SomethingWrapper>>
    {
        public string Url { get; set; }
    }
    internal class WebScrapingHandler : IRequestHandler<WebScrapingCommand, List<SomethingWrapper>>
    {
        private readonly IWebScrapingManager _webScrapingManager;
        public WebScrapingHandler(IWebScrapingManager webScrapingManager)
        {
            _webScrapingManager = webScrapingManager;
        }
        public async Task<List<SomethingWrapper>> Handle(WebScrapingCommand request, CancellationToken cancellationToken)
        {
            var result = await _webScrapingManager.GetSomethingFromURL(request.Url);
            return result;
        }
    }
}
