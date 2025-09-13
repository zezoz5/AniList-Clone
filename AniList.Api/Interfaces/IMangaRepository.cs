using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.Models;

namespace AniList.Api.Interfaces
{
    public interface IMangaRepository
    {
        public Task<List<Manga>> GetMangasAsync();
        public Task<Manga?> GetMangaByIdAsync(int id);
        public Task<Manga> CreateMangaAsync(Manga manga);
        public Task UpdateMangaAsync(Manga manga);
        public Task<bool> DeleteMangaAsync(int id);
    }
}