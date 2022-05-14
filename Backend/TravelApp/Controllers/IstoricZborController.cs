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
    public class IstoricZborController : BaseApplicationController
    {
        private readonly IIstoricZborManager _repository;
        public IstoricZborController(IIstoricZborManager repository)
        {
            _repository = repository;
        }

        [HttpGet("{idZborbyUser}")]
        public async Task<IstoricZbor> GetIstoricZbor(Guid IdUser)
        {
            var rez = await _repository.GetIstoricZbor(IdUser);
            return rez;
        }

        [HttpGet("{idZborbyId}")]
        public async Task<dynamic> GetZborById(Guid userid)
        {
            var rez = await _repository.GetZborById(userid);
            return rez;
        }
        [HttpGet("{idName}")]
        public async Task<dynamic> GetZborByName(string Username)
        {
            var rez = await _repository.GetZborByName(Username);
            return rez;

        }
        [HttpPost]
        public async Task<IActionResult> CreateZbor(CreateZborDTO zbor)
        {
            IstoricZbor istoricZbor = new IstoricZbor();
            istoricZbor.Id = zbor.Id;
            istoricZbor.IdUser = zbor.IdUser;
            istoricZbor.data_plecare = zbor.data_plecare;
            istoricZbor.data_retur = zbor.data_retur;
            istoricZbor.oras_plecare = zbor.oras_plecare;
            istoricZbor.oras_sosire = zbor.oras_sosire;
            istoricZbor.buget = zbor.buget;
            _repository.Create(istoricZbor);
            await _repository.SaveAsync();
            return Ok(new IstoricZborDTO(istoricZbor));

        }
    }
}
