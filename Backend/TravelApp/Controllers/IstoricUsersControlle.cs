using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
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
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class IstoricUsersController : BaseApplicationController
    {
        private readonly IIstoricVacanteManager _repository;
        public IstoricUsersController(IIstoricVacanteManager repository)
        {
            _repository = repository;
        }
        [HttpGet("GetIstoricZbor/{IdUser}")]
        [Authorize(Roles = "User")]

        public async Task<IstoricZbor> GetIstoricZbor(Guid IdUser)
        {

            var result = await _repository.GetIstoricZbor(IdUser);
            return (IstoricZbor)result;
        }

        [HttpGet("idUser/{userid}")]
        [Authorize(Roles = "User")]
        public async Task<dynamic> GetVacanteByUser(Guid userid)
        {
            var rez = await _repository.GetVacanteByUser(userid);
            return rez;


        }
        [HttpGet("idVacanta/{id}")]
        public async Task<dynamic> GetIdVacanta(Guid id)
        {
            var rez = await _repository.GetIdVacanta(id);
            return rez;
        }
        [HttpPost]
        public async Task<IActionResult> CreateIstoric(CreateVacantaDTO v)
        {
            IstoricVacante ist = new IstoricVacante();
            ist.ZborId = v.ZborId;
            ist.Cazariid = v.Cazariid;
            _repository.Create(ist);
            await _repository.SaveAsync();
            return Ok(new IstoricVacantaDTO(ist));

        }
    }
}
