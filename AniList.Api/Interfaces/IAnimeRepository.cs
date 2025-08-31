using AniList.Api.Models;

namespace AniList.Api.Interfaces
{
    public interface IAnimeRepository
    {
        public Task<List<Anime>> GetAllAsync();
        public Task<Anime?> GetByIdAsync(int id);
        public Task<Anime> CreateAnimeAsync(Anime anime);
        public Task UpdateAnimeAsync(Anime anime);
        public Task<bool> DeleteAnimeAsync(int id);
        public Task<bool> ExistAsync(int id);
    }
}