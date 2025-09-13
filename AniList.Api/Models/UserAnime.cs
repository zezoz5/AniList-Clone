using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AniList.Api.Models
{
    public class UserAnime
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        // Tracking data
        public string Status { get; set; } = "Planing"; // Watching, Completed, etc.
        public int Progress { get; set; } = 0;
        public double Score { get; set; } = 0;

    }
}