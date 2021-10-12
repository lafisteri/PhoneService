using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesBusinessLayer;
using PhonesBusinessLayer.DTOs;
using PhonesCore.Models;

namespace PhoneService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhonesController : ControllerBase
    {
        private static PhonesService _phonesService;

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

        [HttpPost]
        public async Task<IActionResult> CreatePhone(PhoneDTO phone)
        {
            var guid = await _phonesService.CreatePhone(phone);

            if(guid != Guid.Empty)
            {
                return Ok(guid);
            }

            return BadRequest();
        }
    }
}
