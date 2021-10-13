using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesBusinessLayer;
using PhonesBusinessLayer.DTOs;

namespace PhonePresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhonesController : ControllerBase
    {
        private static IPhonesService _phonesService;

        public PhonesController()
        {
            _phonesService = new PhonesService();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhones()
        {
            var items = await _phonesService.GetAllPhones();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var items = await _phonesService.GetById(id);

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhone(PhoneDTO phone)
        {
            var guid = await _phonesService.CreatePhone(phone);

            if (guid != Guid.Empty)
            {
                return Ok(guid);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhone(Guid id, PhoneDTO phoneDTO)
        {
            var updatedPhone = await _phonesService.UpdatePhone(id, phoneDTO);

            if (updatedPhone != null)
            {
                return Ok(updatedPhone);
            }

            return BadRequest($"Phone with id {id} was not updated!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhone(Guid id)
        {
            var updatedPhone = await _phonesService.DeletePhone(id);

            if (updatedPhone != null)
            {
                return Ok(updatedPhone);
            }

            return BadRequest($"Phone with id {id} was not deleted!");
        }

    }
}
