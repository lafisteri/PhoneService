using System.Collections.Generic;
using System.Threading.Tasks;
using PhonesCore.Models;
using PhonesDataLayer;

namespace PhonesBusinessLayer
{
    public class PhonesService
    {
        private static PhonesRepository _phonesRepository;

        static PhonesService()
        {
            _phonesRepository = new PhonesRepository();
        }

        public async Task<IEnumerable<Phone>> GetAllPhones()
        {
            await Task.CompletedTask;

            return _phonesRepository.GetAllPhones();
        }
    }
}
