using System;
using AutoMapper;
using Core.Enums;
using Core.Models;
using BusinessLayer.DTOs;

namespace BusinessLayer.MapperProfile
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<PhoneDTO, Phone>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.ColorId, opt => opt.MapFrom(src => ToCategory(src.Color)))
                .ForMember(x => x.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(x => x.IsEsim, opt => opt.MapFrom(src => src.IsEsim))
                .ForMember(x => x.DisplayDiagonal, opt => opt.MapFrom(src => src.DisplayDiagonal))
                .ForMember(x => x.PresentationDay, opt => opt.MapFrom(src => src.PresentationDay));
        }

        private Color ToCategory(string category)
        {
            return Enum.TryParse(typeof(Color), category, out var result)
                ? (Color)result
                : default;
        }
    }
}
