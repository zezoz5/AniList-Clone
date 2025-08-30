using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.DTOs;
using AniList.Api.Models;
using AutoMapper;

namespace AniList.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anime, AnimeDto>();
            CreateMap<CreateAnimeDto, Anime>();
        }
    }
}