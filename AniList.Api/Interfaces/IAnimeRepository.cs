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
        public Task<List<Anime>> GetAllAsync();
        public Task<Anime?> GetByIdAsync(int Id);
        public Task<Anime> CreateAnimeAsync(Anime anime);
        public Task<bool> UpdateAnimeAsync(Anime anime);
        public Task<bool> DeleteAnimeAsync(int Id);
        public Task<bool> ExistAsync(int Id);
    }
}