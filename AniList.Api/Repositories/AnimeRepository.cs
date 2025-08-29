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
        private readonly IMapper _mapper;

        public AnimeRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnimeDto>> GetAllAsync()
        {
            var animeList = await _context.Animes.ToListAsync();
            return _mapper.Map<List<AnimeDto>>(animeList);

        }

        public async Task<AnimeDto?> GetByIdAsync(int Id)
        {
            var anime = await _context.Animes.FindAsync(Id);

            return _mapper.Map<AnimeDto>(anime);
        }

        public async Task<AnimeDto> AddAnimeAsync(AddAnimeDto animeDto)
        {
            var anime = _mapper.Map<Anime>(animeDto);
            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();
            return _mapper.Map<AnimeDto>(anime);
        }

        public async Task<AnimeDto?> UpdateAnimeAsync(int Id, AddAnimeDto updatedAnime)
        {
            var anime = _mapper.Map<Anime>(updatedAnime);
            anime.Id = Id;

            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();

            var animeDto = _mapper.Map<AnimeDto>(anime);

            return animeDto;
        }

        public async Task<AnimeDto?> DeleteAnimeAsync(int Id)
        {
            var anime = await _context.Animes.FindAsync(Id);
            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();
            return _mapper.Map<AnimeDto>(anime);
        }
    }
}