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
    public class UserMangaRepository : IUserMangaRepository
    {
        private readonly AppDbContext _context;

        public UserMangaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserManga>> GetMangasForUserAsync(int userId)
        {
            return await _context.UserMangas.Where(um => um.UserId == userId)
            .Include(m => m.Manga).ToListAsync();
        }
        public async Task<UserManga?> GetMangaByIdForUserAsync(int userId, int mangaId)
        {
            return await _context.UserMangas
                .FirstOrDefaultAsync(um => um.UserId == userId && um.MangaId == mangaId);
        }

        public async Task<UserManga> AddMangaToUserAsync(UserManga userManga)
        {
            await _context.UserMangas.AddAsync(userManga);
            await _context.SaveChangesAsync();
            return userManga;
        }

        public async Task UpdateUserManga(UserManga userManga)
        {
            _context.UserMangas.Update(userManga);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteMangaFromUser(int userId, int mangaId)
        {
            var manga = await _context.UserMangas
            .FirstOrDefaultAsync(um => um.UserId == userId && um.MangaId == mangaId);

            if (manga == null)
                return false;

            _context.UserMangas.Remove(manga);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}