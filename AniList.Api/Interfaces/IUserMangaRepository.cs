using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.Models;

namespace AniList.Api.Interfaces
{
    public interface IUserMangaRepository
    {
        public Task<List<UserManga>> GetMangasForUserAsync(int userId);
        public Task<UserManga?> GetMangaByIdForUserAsync(int userId, int animeId);
        public Task<UserManga> AddMangaToUserAsync(UserManga userManga);
        public Task UpdateUserManga(UserManga userManga);
        public Task<bool> DeleteMangaFromUser(int userId, int mangaId);
    }
}