using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AniList.Api.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Romaji { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public int Episodes { get; set; }
        public string Status { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Season { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string Studio { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Synonyms { get; set; } = string.Empty;
        //public byte[] Image { get; set; } = null!;


        //List of tracking entries:
        public List<UserAnime> Viewers { get; private set; } = [];
        // Navigation property
        public ICollection<Genre> Genres { get; set; } = [];
    }
}