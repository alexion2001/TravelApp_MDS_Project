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
    public class CazariUsersController : BaseApplicationController
    {
        private readonly ICazariUsersManager _repository;
        public CazariUsersController(ICazariUsersManager repository)
        {
            _repository = repository;
        }
        [HttpGet("GetCazari/{id}")]
        public async Task<CazariUsers> GetCazari(Guid id)
        {
            var rez = await _repository.GetCazari(id);
            return rez;
        }
        [HttpGet("GetCazariByUser/{user}")]
        public async Task<dynamic> GetCazariByUser(Guid user)
        {
            var rez = await _repository.GetCazariByUser(user);
            return rez;
        }
        [HttpGet("GetCazariByUserStatus/{user}")]
        public async Task<dynamic> GetCazariByUserStatus(Guid user, String status)
        {
            var rez = await _repository.GetCazariByUserStatus(user, status);
            return rez;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCazari(CreateCazariUsersDTO cazare, String status)
        {
            CazariUsers istoriccazare = new CazariUsers();
            istoriccazare.Id = Guid.NewGuid();
            istoriccazare.UserId = cazare.UserId;
            istoriccazare.CazareId = cazare.CazareId;
            istoriccazare.Status = status;
       
            _repository.Create(istoriccazare, status);
            await _repository.SaveAsync();
            return Ok(new CazariUsersDTO(istoriccazare));

        }

    }
}
