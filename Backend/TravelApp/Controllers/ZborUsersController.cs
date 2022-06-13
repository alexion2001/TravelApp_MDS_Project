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
    public class ZborUsersController : BaseApplicationController
    {
        private readonly IZboruriUsersManager _repository;
        public ZborUsersController(IZboruriUsersManager repository)
        {
            _repository = repository;
        }

        [HttpGet("GetZboruri/{id}")]
        public async Task<ZboruriUsers> GetZboruri(Guid id)
        {
            var rez = await _repository.GetZboruri(id);
            return rez;
        }
        [HttpGet("GetZborByUser/{user}")]
        public async Task<dynamic> GetZborByUser(Guid user)
        {
            var rez = await _repository.GetZborByUser(user);
            return rez;
        }

        [HttpGet("GetZboruriByUserStatus/{user}")]
        public async Task<dynamic> GetZboruriByUserStatus(Guid user, String status)
        {
            var rez = await _repository.GetZboruriByUserStatus(user,status);
            return rez;
        }
        [HttpPost]
        public async Task<IActionResult> CreateZboruri(CreateZboruriUsersDTO zb, String status)
        {
            ZboruriUsers zbor = new ZboruriUsers();
            zbor.Id = zb.Id;
            zbor.UserId = zb.UserId;
            zbor.ZborId = zb.ZborId;
            zbor.Status = status;
            _repository.Create(zbor);
            await _repository.SaveAsync();
            return Ok(new ZboruriUsersDTO(zbor));

        }
    }
}
