using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AniList.Api.Models
{
    public class UserManga
    {
        public int MangaId { get; set; }
        public Manga Manga { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // Tracking
        public string Status { get; set; } = "Planning";
        public int Progress { get; set; } = 0; // Chapters read
        public int Score { get; set; } = 0;
    }
}