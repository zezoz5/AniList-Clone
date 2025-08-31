using AniList.Api.DTOs;
using AniList.Api.Interfaces;
using AniList.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Get all anime entries.
        /// </summary>
        /// <remarks>Returns a list of all anime in the database.</remarks>
        /// <response code="200">Returns the list of anime</response>
        [HttpGet]
        public async Task<IActionResult> GetAllAnimes()
        {
            var anime = await _repository.GetAllAsync();
            var animeDto = _mapper.Map<List<AnimeDto>>(anime);
            return Ok(animeDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimeById([FromRoute] int id)
        {
            var anime = await _repository.GetByIdAsync(id);
            if (anime == null) return NotFound(new { message = $"Anime with ID {id} was not found." });
            var animeDto = _mapper.Map<AnimeDto>(anime);
            return Ok(animeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnime([FromBody] CreateAnimeDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var anime = _mapper.Map<Anime>(createDto);
            var newAnime = await _repository.CreateAnimeAsync(anime);
            var animeDto = _mapper.Map<AnimeDto>(newAnime);
            return CreatedAtAction(nameof(GetAnimeById), new { id = newAnime.Id }, animeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnime([FromRoute] int id, CreateAnimeDto createAnimeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _repository.ExistAsync(id))
                return NotFound(new { message = $"Anime with ID {id} was not found." });

            var anime = _mapper.Map<Anime>(createAnimeDto);
            anime.Id = id;

            await _repository.UpdateAnimeAsync(anime);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime([FromRoute] int id)
        {
            var isDeleted = await _repository.DeleteAnimeAsync(id);

            if (!isDeleted)
                return NotFound(new { message = $"Anime with ID {id} was not found." });

            return NoContent();
        }
    }
}