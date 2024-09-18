using AutoMapper;
using Desafio.Decompor.Api.ViewModels;
using DomainObject = Desafio.Decompor.Business.Domain;

namespace Desafio.Decompor.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<DomainObject.Decompor, DecomporViewModel>().ReverseMap();
        }
    }
}