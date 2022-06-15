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
    public class RecenziiUserController : BaseApplicationController
    {
        private readonly IRecenziiUserManager _repository;
        public RecenziiUserController(IRecenziiUserManager repository)
        {
            _repository = repository;
        }
        [HttpGet("GetRecenzii/{userid}")]
        public async Task<dynamic> GetRecenzii(Guid userid)
        {
            var rez = await _repository.GetRecenzii(userid);
            return rez;
        }

        [HttpGet("GetNumeUser/{userid}")]
        public async Task<dynamic> GetNumeUser(Guid userid)
        {
            var rez = await _repository.GetRecenzii(userid);
            return rez;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRcenzii(CreateRecenziiUserDTO rec)
        {
            RecenziiUsers recenzie = new RecenziiUsers();
            recenzie.UserId = rec.UserId;
            recenzie.IdMesaj = rec.IdMesaj;
            recenzie.DataMesaj = rec.DataMesaj;
            _repository.Create(recenzie);
            await _repository.SaveAsync();
            return Ok(new RecenziiUserDTO(recenzie));

        }

        [HttpDelete("{idMesaj}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var RecenziiUsers = await _repository.GetById(id);
            if (RecenziiUsers == null)
            {
                return NotFound("Nu exista.");
            }
            _repository.Delete(RecenziiUsers);

            await _repository.SaveAsync();

            return NoContent();

        }
        
    }
}
