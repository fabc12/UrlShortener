using System.Collections.Generic;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UrlMapper, GetShortUrlsDto>().ForMember(d => d.ShortUrls,
            o => o.MapFrom(s => s.ShortUrl));
        }
    }
}