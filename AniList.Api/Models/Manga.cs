using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AniList.Api.Models
{
    public class Manga
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Romaji { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public string Chapters { get; set; } = string.Empty;
        public string Volumes { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string Source { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Synonyms { get; set; } = string.Empty;
        public byte[] Image { get; set; } = [];

        // List of tracked data
        public List<UserManga> Readers { get; set; } = [];

        // Navigation property
        public ICollection<Genre> Genres { get; set; } = [];
        
    }
}