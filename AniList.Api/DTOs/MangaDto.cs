using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AniList.Api.DTOs
{
    public class MangaDto
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
        
    }
}