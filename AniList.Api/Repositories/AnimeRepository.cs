using AniList.Api.data;
using AniList.Api.Interfaces;
using AniList.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AniList.Api.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AppDbContext _context;

        public AnimeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Anime>> GetAllAsync()
        {
            return await _context.Animes.ToListAsync();
        }
        public async Task<Anime?> GetByIdAsync(int id)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.Id == id);
            return anime;
        }
        public async Task<Anime> CreateAnimeAsync(Anime anime)
        {
            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();
            return anime;
        }

        public async Task UpdateAnimeAsync(Anime anime)
        {
            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAnimeAsync(int id)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.Id == id);
            if (anime == null) return false;
            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Animes.AnyAsync(x => x.Id == id);
        }
    }
}