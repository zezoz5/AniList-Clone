using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.DTOs;
using AniList.Api.Interfaces;
using AniList.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AniList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAnimeController : ControllerBase
    {
        private readonly IUserAnimeRepository _repository;
        private readonly IAnimeRepository _animeRepository;
        private readonly IMapper _mapper;

        public UserAnimeController(IUserAnimeRepository repository, IMapper mapper, IAnimeRepository animeRepository)
        {
            _repository = repository;
            _animeRepository = animeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetWatchlist()
        {
            // var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var userId = 1;
            var entries = await _repository.GetByUserIdAsync(userId);
            var entriesDto = _mapper.Map<List<UserAnimeDto>>(entries);
            return Ok(entriesDto);
        }

        [HttpGet("{animeId}")]
        public async Task<IActionResult> GetEntry(int animeId)
        {
            // var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var userId = 1;
            var entry = await _repository.GetByUserAndAnimeAsync(userId, animeId);
            if (entry == null)
                return NotFound(new { message = "This anime is not in your list" });
            var entryDto = _mapper.Map<UserAnimeDto>(entry);
            return Ok(entryDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist([FromBody] AddUserAnimeDto AddDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = 1;

            // Prevent duplicates
            var exists = await _repository.GetByUserAndAnimeAsync(userId, AddDto.AnimeId);
            if (exists != null)
                return Conflict(new { message = "Anime is already in your list." });

            // Validate anime exists
            var animeExist = await _animeRepository.ExistAsync(AddDto.AnimeId);
            if (!animeExist)
                return BadRequest(new { message = "Anime not found" });

            var userAnime = _mapper.Map<UserAnime>(AddDto);
            userAnime.UserId = userId;

            var added = await _repository.AddAsync(userAnime);
            var dto = _mapper.Map<UserAnimeDto>(added);

            return CreatedAtAction(nameof(GetEntry), new { animeId = added.AnimeId, dto });
        }


    }
}