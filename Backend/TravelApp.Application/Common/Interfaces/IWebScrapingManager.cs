using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.ViewModels.External.SomethingWrapper;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IWebScrapingManager
    {
        Task<List<SomethingWrapper>> GetSomethingFromURL(string url);
    }
}
