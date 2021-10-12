using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhonesBusinessLayer.DTOs;
using PhonesCore.Enums;
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

        public async Task<Guid> CreatePhone(PhoneDTO phoneDTO)
        {
            await Task.CompletedTask;
            if(Enum.TryParse(typeof(Color), phoneDTO.Color, out var color))
            {
                var phone = new Phone
                {
                    Model = phoneDTO.Model,
                    IsEsim = phoneDTO.IsEsim,
                    DisplayDiagonal = phoneDTO.DisplayDiagonal,
                    PresentationDay = phoneDTO.PresentationDay,
                    Color = (Color)color
                };

                return _phonesRepository.CreatePhone(phone);
            }

            return Guid.Empty;
        }
    }
}
