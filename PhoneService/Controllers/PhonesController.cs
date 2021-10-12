using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesBusinessLayer;

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
    }
}
