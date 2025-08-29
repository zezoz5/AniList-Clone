using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AniList.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public List<UserAnime> AnimeList { get; private set; } = [];
        public List<UserManga> MangaList { get; private set; } = [];
        
    }
}