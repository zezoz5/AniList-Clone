using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.data;
using AniList.Api.DTOs;
using AniList.Api.Interfaces;
using AniList.Api.Models;
using AutoMapper;
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
            var animeList = await _context.Animes.ToListAsync();
            return animeList;
        }
        public async Task<Anime?> GetByIdAsync(int Id)
        {
            var anime = await _context.Animes.FindAsync(Id);
            return anime;
        }
        public async Task<Anime> CreateAnimeAsync(Anime anime)
        {
            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();
            return anime;
        }

        public async Task<bool> UpdateAnimeAsync(Anime anime)
        {
            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAnimeAsync(int Id)
        {
            var anime = await _context.Animes.FindAsync(Id);
            if (anime == null) return false;
            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistAsync(int Id)
        {
            return await _context.Animes.AnyAsync(x => x.Id == Id);
        }
    }
}