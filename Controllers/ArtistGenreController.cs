using System;
using System.Collections.Generic;
using GenreLibrary.Models;
using GenreLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenreLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistGenreController:ControllerBase
    {
        private readonly ArtistGenreService _service;
        public ArtistGenreController(ArtistGenreService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<DTOArtistGenre> Post([FromBody] DTOArtistGenre newDTOArtistGenre)
        {
            try
            {
                return Ok(_service.Create(newDTOArtistGenre));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<DTOArtistGenre> Delete(int id)
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