using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.Models;

namespace AniList.Api.Interfaces
{
    public interface IUserAnimeRepository
    {
        public Task<List<UserAnime>> GetByUserIdAsync(int id);
        public Task<UserAnime?> GetByUserAndAnimeAsync(int userId, int animeId);
        public Task<UserAnime> AddAsync(UserAnime userAnime);
        public Task UpdateAsync(UserAnime userAnime);
        public Task<bool> DeleteAsync(int userId, int animeId);
    }
}