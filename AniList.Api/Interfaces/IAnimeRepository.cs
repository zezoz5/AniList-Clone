using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.DTOs;
using AniList.Api.Models;

namespace AniList.Api.Interfaces
{
    public interface IAnimeRepository
    {
        public Task<IEnumerable<AnimeDto>> GetAllAsync();
        public Task<AnimeDto?> GetByIdAsync(int Id);
        public Task<AnimeDto> AddAnimeAsync(AddAnimeDto animeDto);
        public Task<AnimeDto?> UpdateAnimeAsync(int Id, AddAnimeDto animeDto);
        public Task<AnimeDto?> DeleteAnimeAsync(int Id);
    }
}