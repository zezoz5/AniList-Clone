using AniList.Api.DTOs;
using AniList.Api.Interfaces;
using AniList.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AniList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserMangaController : ControllerBase
    {
        private readonly IUserMangaRepository _repository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;

        public UserMangaController(IUserMangaRepository repository, IMapper mapper, IMangaRepository mangaRepository)
        {
            _repository = repository;
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetReadlist()
        {
            var userId = 1;
            var mangas = await _repository.GetMangasForUserAsync(userId);
            var mangasDto = _mapper.Map<List<UserMangaDto>>(mangas);
            return Ok(mangasDto);
        }

        [HttpGet("{mangaId}")]
        public async Task<IActionResult> GetEntry(int mangaId)
        {
            var userId = 1;
            var entry = await _repository.GetMangaByIdForUserAsync(userId, mangaId);
            if (entry == null)
                return NotFound(new { message = "Manga not found" });
            var entryDto = _mapper.Map<UserMangaDto>(entry);
            return Ok(entryDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddToReadlist([FromBody] AddUserMangaDto addDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = 1;

            // Prevent duplicates
            var exists = await _repository.GetMangaByIdForUserAsync(userId, addDto.MangaId);

            if (exists != null)
                return Conflict(new { message = "Manga already in your Readlist" });

            // Check if manga exist
            var mangaExist = await _mangaRepository.GetMangaByIdAsync(addDto.MangaId);
            if (mangaExist == null)
                return BadRequest(new { message = "Manga doesn't exist" });

            var userManga = _mapper.Map<UserManga>(addDto);
            userManga.UserId = userId;

            var added = await _repository.AddMangaToUserAsync(userManga);
            var dto = _mapper.Map<UserMangaDto>(added);

            return CreatedAtAction(nameof(GetEntry), new { mangaId = added.MangaId }, dto);
        }

        [HttpPut("{mangaId}")]
        public async Task<IActionResult> UpdateEntry(int mangaId, [FromBody] UserMangaUpdateDto UpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = 1;

            var userManga = await _repository.GetMangaByIdForUserAsync(userId, mangaId);

            if (userManga == null)
                return NotFound(new { message = "Manga not in your Readlist" });

            _mapper.Map(UpdateDto, userManga);
            await _repository.UpdateUserManga(userManga);
            return NoContent();
        }

        [HttpDelete("{mangaId}")]
        public async Task<IActionResult> DeleteEntry([FromRoute] int mangaId)
        {
            var userId = 1;
            var success = await _repository.DeleteMangaFromUser(userId, mangaId);

            if (!success)
                return NotFound(new { message = "Manga not found in your Readlist" });

            return NoContent();
        }
    }
}