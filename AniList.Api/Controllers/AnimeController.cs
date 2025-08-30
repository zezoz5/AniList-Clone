using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.data;
using AniList.Api.DTOs;
using AniList.Api.Interfaces;
using AniList.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AniList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeRepository _repository;
        private readonly IMapper _mapper;

        public AnimeController(IAnimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimes()
        {
            var anime = await _repository.GetAllAsync();
            var animeDto = _mapper.Map<List<AnimeDto>>(anime);
            return Ok(animeDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAnimeById([FromRoute] int Id)
        {
            var anime = await _repository.GetByIdAsync(Id);
            if (anime == null) return NotFound("Couldn't find your anime");
            var animeDto = _mapper.Map<AnimeDto>(anime);
            return Ok(animeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnime([FromBody] CreateAnimeDto createDto)
        {
            var anime = _mapper.Map<Anime>(createDto);
            var newAnime = await _repository.CreateAnimeAsync(anime);
            var animeDto = _mapper.Map<AnimeDto>(newAnime);
            return Ok(animeDto);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAnime([FromRoute] int Id, CreateAnimeDto createAnimeDto)
        {
            if (!await _repository.ExistAsync(Id))
                return NotFound($"Anime with ID {Id} was not found.");

            var anime = _mapper.Map<Anime>(createAnimeDto);
            anime.Id = Id;

            await _repository.UpdateAnimeAsync(anime);

            var animeDto = _mapper.Map<AnimeDto>(anime);
            return Ok(animeDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAnime([FromRoute] int Id)
        {
            var isDeleted = await _repository.DeleteAnimeAsync(Id);

            if (!isDeleted)
                return NotFound($"Anime with ID {Id} was not found.");

            return NoContent();
        }
    }
}