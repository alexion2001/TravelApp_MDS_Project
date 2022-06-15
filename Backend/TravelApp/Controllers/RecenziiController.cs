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
    public class RecenziiController : BaseApplicationController
    {
        private readonly IRecenziiManager _repository;
        public RecenziiController(IRecenziiManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRec()
        {
            var ang = await _repository.GetAllRec();

            var angToReturn = new List<RecenziiDTO>();

            foreach (var angajat in ang)
            {
                angToReturn.Add(new RecenziiDTO(angajat));
            }

            return Ok(angToReturn);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRcenzii(CreateRecenziiDTO rec)
        {
            Recenzii recenzie = new Recenzii();
            recenzie.Id = Guid.NewGuid();
            recenzie.Oras = rec.Oras;
            recenzie.Mesaj = rec.Mesaj;
            _repository.Create(recenzie);
            await _repository.SaveAsync();
            return Ok(new RecenziiDTO(recenzie));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var Recenzii = await _repository.GetById(id);
            if (Recenzii == null)
            {
                return NotFound("Nu exista.");
            }
            _repository.Delete(Recenzii);

            await _repository.SaveAsync();

            return NoContent();


        }
        [HttpPatch("{idMesaj}")]
        public async Task<IActionResult> Update(Guid idMesaj, string mesaj)
        {
            Recenzii update = await _repository.GetById(idMesaj);
            update.Mesaj = mesaj;
            _repository.Update(update);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
