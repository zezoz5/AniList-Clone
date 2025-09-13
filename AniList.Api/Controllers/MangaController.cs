using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.DTOs;
using AniList.Api.Interfaces;
using AniList.Api.Models;
using AniList.Api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AniList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangaController : ControllerBase
    {
        private readonly IMangaRepository _repository;
        private readonly IMapper _mapper;

        public MangaController(IMangaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetMangas()
        {
            var mangas = await _repository.GetMangasAsync();
            var mangasDto = _mapper.Map<List<MangaDto>>(mangas);
            return Ok(mangasDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMangaById([FromRoute] int id)
        {
            var manga = await _repository.GetMangaByIdAsync(id);
            if (manga == null)
                return NotFound(new { message = "Couldn't find your manga" });

            var mangaDto = _mapper.Map<MangaDto>(manga);
            return Ok(mangaDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddManga([FromBody] AddMangaDto addMangaDto)
        {
            var manga = _mapper.Map<Manga>(addMangaDto);
            var newManga = await _repository.CreateMangaAsync(manga);

            var mangaDto = _mapper.Map<MangaDto>(newManga);
            return Ok(mangaDto);
        }

        [HttpPut("{mangaId}")]
        public async Task<IActionResult> UpdateManga([FromRoute] int mangaId, AddMangaDto addMangaDto)
        {
            var manga = _mapper.Map<Manga>(addMangaDto);
            manga.Id = mangaId;

            await _repository.UpdateMangaAsync(manga);

            return NoContent();
        }

        [HttpDelete("{mangaId}")]
        public async Task<IActionResult> DeleteManga([FromRoute] int mangaId)
        {
            var isDeleted = await _repository.DeleteMangaAsync(mangaId);
            if (isDeleted == false)
                return NotFound(new { message = "Manga does not exist" });
            return NoContent();
        }
    }
}