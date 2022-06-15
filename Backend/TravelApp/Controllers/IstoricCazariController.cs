using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Application.ViewModels.AppInternal;
using TravelApp.Domain.Entities;

namespace TravelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IstoricCazariController : BaseApplicationController
    {
        private readonly IIstoricCazariManager _repository;
        private readonly IUserManager _rep;
        public IstoricCazariController(IIstoricCazariManager repository, IUserManager rep)
        {
            _repository = repository;
            _rep = rep;
        }

        [HttpGet("GetUserByUsername/{username}")]
        public async Task<Guid> GetUserByUsername(string username)
        {
            var rez = await _rep.GetUserByUsername(username);
            return rez;
        }

        [HttpGet("idUserForCazari/{Id}")]
        public async Task<IstoricCazari> GetIstoricCazari(Guid Id)
        {
            var rez = await _repository.GetIstoricCazari(Id);
            return rez;
        }
        [HttpGet("GetCazariByOras/{oras}")]
        public async Task<IstoricCazari> GetCazariByOras(String oras)
        {
            var rez = await _repository.GetCazariByOras(oras);
            return rez;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateCazari(CreateCazareDTO cazare)
        {
            IstoricCazari istoriccazare = new IstoricCazari();
            istoriccazare.Id = Guid.NewGuid();
            istoriccazare.data_venire = cazare.data_venire;
            istoriccazare.data_plecare = cazare.data_plecare;
            istoriccazare.oras = cazare.oras;
           // istoriccazare.numeLoc = cazare.numeLoc;
            istoriccazare.buget = cazare.buget;
            _repository.Create(istoriccazare);
            await _repository.SaveAsync();
            return Ok(new IstoricCazariDTO(istoriccazare));

        }

  
    }
}
