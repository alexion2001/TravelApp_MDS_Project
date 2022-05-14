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
        public IstoricCazariController(IIstoricCazariManager repository)
        {
            _repository = repository;
        }
        [HttpGet("idUserForCazari/{IdUser}")]
        public async Task<IstoricCazari> GetIstoricCazari(Guid IdUser)
        {
            var rez = await _repository.GetIstoricCazari(IdUser);
            return rez;
        }
        [HttpGet("UsernameForCazari/{username}")]
        public async Task<dynamic> GetCazariByName(String username)
        {
            var rez = await _repository.GetCazariByName(username);
            return rez;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCazari(CreateCazareDTO cazare)
        {
            IstoricCazari istoriccazare = new IstoricCazari();
            istoriccazare.Id = cazare.Id;
            istoriccazare.IdUser = cazare.IdUser;
            istoriccazare.data_venire = cazare.data_venire;
            istoriccazare.data_plecare = cazare.data_plecare;
            istoriccazare.oras = cazare.oras;
            istoriccazare.numeLoc = cazare.numeLoc;
            istoriccazare.buget = cazare.buget;
            _repository.Create(istoriccazare);
            await _repository.SaveAsync();
            return Ok(new IstoricCazariDTO(istoriccazare));

        }
    }
}
