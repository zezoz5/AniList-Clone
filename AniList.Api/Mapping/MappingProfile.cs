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
            CreateMap<UserAnime, UserAnimeDto>();
            CreateMap<UserAnime,AddUserAnimeDto>().ReverseMap();
            CreateMap<UserAnimeUpdateDto, UserAnime>();
            CreateMap<Manga, MangaDto>();
            CreateMap<AddMangaDto, Manga>();
            CreateMap<UserManga, UserMangaDto>();
            CreateMap<UserManga, AddUserMangaDto>().ReverseMap();
            CreateMap<UserMangaUpdateDto, UserManga>();
        }
    }
}