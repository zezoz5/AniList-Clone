using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.data;
using AniList.Api.Interfaces;
using AniList.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AniList.Api.Repositories
{
    public class MangaRepository : IMangaRepository
    {
        private readonly AppDbContext _context;

        public MangaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manga>> GetMangasAsync()
        {
            return await _context.Mangas.ToListAsync();
        }

        public async Task<Manga?> GetMangaByIdAsync(int id)
        {
            return await _context.Mangas.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Manga> CreateMangaAsync(Manga manga)
        {
            await _context.Mangas.AddAsync(manga);
            await _context.SaveChangesAsync();
            return manga;
        }

        public async Task UpdateMangaAsync(Manga manga)
        {
            _context.Mangas.Update(manga);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteMangaAsync(int id)
        {
            var manga = await _context.Mangas.FirstOrDefaultAsync(m => m.Id == id);
            if (manga == null)
                return false;

            _context.Mangas.Remove(manga);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}