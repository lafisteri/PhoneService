using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using BusinessLayer.DTOs;
using DataLayer;
using BusinessLayer.Abstract;

namespace BusinessLayer
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
            return await _phonesRepository.GetAsync();
        }

        public async Task<Phone> GetById(Guid id)
        {
            return await _phonesRepository.GetAsync(id);
        }

        public async Task<Guid> CreatePhone(PhoneDTO phoneDTO)
        {
            var phone = _mapper.Map<Phone>(phoneDTO);
            if (phone != null)
            {
                return await _phonesRepository.CreateAsync(phone);
            }

            return Guid.Empty;
        }

        public async Task<Phone> UpdatePhone(Guid id, PhoneDTO phoneDTO)
        {
            var phone = _mapper.Map<Phone>(phoneDTO);
            if (phone != null)
            {
                phone.Id = id;
                return await _phonesRepository.UpdateAsync(phone);
            }

            return null;
        }

        public async Task<Phone> DeletePhone(Guid id)
        {
            return await _phonesRepository.DeleteAsync(id);
        }
    }
}
