using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PhonesBusinessLayer.DTOs;
using PhonesCore.Enums;
using PhonesCore.Models;
using PhonesDataLayer;

namespace PhonesBusinessLayer
{
    public class PhonesService : IPhonesService
    {
        private static IMapper _mapper;
        private static IPhonesRepository _phonesRepository;

        public PhonesService(IPhonesRepository phonesRepository, IMapper mapper)
        {
            _phonesRepository = phonesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Phone>> GetAllPhones()
        {
            await Task.CompletedTask;

            return _phonesRepository.Get();
        }

        public async Task<Phone> GetById(Guid id)
        {
            await Task.CompletedTask;

            return _phonesRepository.Get(id);
        }

        public async Task<Guid> CreatePhone(PhoneDTO phoneDTO)
        {
            await Task.CompletedTask;

            var phone = _mapper.Map<Phone>(phoneDTO);
            if (phone != null)
            {
                return _phonesRepository.Create(phone);
            }

            return Guid.Empty;
        }

        public async Task<Phone> UpdatePhone(Guid id, PhoneDTO phoneDTO)
        {
            await Task.CompletedTask;

            var phone = _mapper.Map<Phone>(phoneDTO);
            if (phone != null)
            {
                phone.Id = id;
                return _phonesRepository.Update(phone);
            }

            return null;
        }

        public async Task<Phone> DeletePhone(Guid id)
        {
            await Task.CompletedTask;

            return _phonesRepository.Delete(id);
        }

    }
}
