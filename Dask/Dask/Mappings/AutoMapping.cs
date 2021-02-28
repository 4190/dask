using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dask.Models;



namespace TSearch.Controllers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //CreateMap<model, modelDTO>().ReverseMap();
            //CreateMap<model, modelDTO>()
            //    .ForMember(dest => dest.destinationProperty, opt => opt.MapFrom(src => src.sourceProperty))
            //    .ForMember(dest => dest.destinationProperty, opt => opt.MapFrom(src => src.sourceProperty));

        }
    }
}
