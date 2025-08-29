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

        public AnimeController(IAnimeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimes()
        {
            var anime = await _repository.GetAllAsync();
            return Ok(anime);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAnimeById([FromRoute] int Id)
        {
            var anime = await _repository.GetByIdAsync(Id);
            if (anime == null) return NotFound("Couldn't find the anime");
            return Ok(anime);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnime([FromBody] AddAnimeDto animeDto)
        {
            var anime = await _repository.AddAnimeAsync(animeDto);
            return Ok(anime);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAnime([FromRoute] int Id, [FromBody] AddAnimeDto updatedAnime)
        {
            await _repository.UpdateAnimeAsync(Id, updatedAnime);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAnime([FromRoute] int Id)
        {
            await _repository.DeleteAnimeAsync(Id);
            return NoContent();
        }
    }
}