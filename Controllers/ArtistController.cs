using System;
using System.Collections.Generic;
using GenreLibrary.Models;
using GenreLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenreLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController:ControllerBase
    {
        private readonly ArtistService _service;
        private readonly ArtistGenreService _agService;
        public ArtistController(ArtistService service, ArtistGenreService agService)
        {
            _service = service;
            _agService = agService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Artist>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

                
        [HttpGet("{id}/genre")]
        public ActionResult<IEnumerable<ArtistGenre>> GetGenreByArtistId(int id)
        {
        try
        {
            return Ok(_agService.GetGenreByArtistId(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        }

        [HttpPost]
        public ActionResult<Artist> Post([FromBody] Artist newArtist)
        {
            try
            {
                return Ok(_service.Create(newArtist));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Artist> Edit([FromBody] Artist newArtist, int id)
        {
            try
            {
                newArtist.Id = id;
                return Ok(_service.Edit(newArtist));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Artist> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}