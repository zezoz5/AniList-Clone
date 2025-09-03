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
    public class UserAnimeRepository : IUserAnimeRepository
    {
        private readonly AppDbContext _context;

        public UserAnimeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserAnime>> GetByUserIdAsync(int id)
        {
            return await _context.UserAnimes.Where(ua => ua.UserId == id).Include(ua => ua.Anime).ToListAsync();
        }

        public async Task<UserAnime?> GetByUserAndAnimeAsync(int userId, int animeId)
        {
            return await _context.UserAnimes
                .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AnimeId == animeId);
        }

        public async Task<UserAnime> AddAsync(UserAnime userAnime)
        {
            await _context.UserAnimes.AddAsync(userAnime);
            await _context.SaveChangesAsync();
            return userAnime;
        }
    }
}