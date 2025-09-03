using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AniList.Api.DTOs
{
    public class UserAnimeDto
    {
        public int AnimeId { get; set; }
        public string AnimeTitle { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Progress { get; set; } 
        public double Score { get; set; }
    }
}