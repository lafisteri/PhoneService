using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhonesBusinessLayer.DTOs;
using PhonesCore.Enums;
using PhonesCore.Models;
using PhonesDataLayer;

namespace PhonesBusinessLayer
{
    public class PhonesService : IPhonesService
    {
        private static IPhonesRepository _phonesRepository;

        public PhonesService(IPhonesRepository phonesRepository)
        {
            _phonesRepository = phonesRepository;
        }

        public async Task<IEnumerable<Phone>> GetAllPhones()
        {
            await Task.CompletedTask;

            return _phonesRepository.GetAllPhones();
        }

        public async Task<Phone> GetById(Guid id)
        {
            await Task.CompletedTask;

            return _phonesRepository.GetById(id);
        }

        public async Task<Guid> CreatePhone(PhoneDTO phoneDTO)
        {
            await Task.CompletedTask;
            if (Enum.TryParse(typeof(Color), phoneDTO.Color, out var color))
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

        public async Task<Phone> UpdatePhone(Guid id, PhoneDTO phoneDTO)
        {
            await Task.CompletedTask;

            if (Enum.TryParse(typeof(Color), phoneDTO.Color, out var color))
            {
                var phone = new Phone
                {
                    Id = id,
                    Model = phoneDTO.Model,
                    IsEsim = phoneDTO.IsEsim,
                    DisplayDiagonal = phoneDTO.DisplayDiagonal,
                    PresentationDay = phoneDTO.PresentationDay,
                    Color = (Color)color
                };

                return _phonesRepository.UpdatePhone(phone);
            }

            return null;
        }

        public async Task<Phone> DeletePhone(Guid id)
        {
            await Task.CompletedTask;

            return _phonesRepository.DeletePhone(id);
        }

    }
}
