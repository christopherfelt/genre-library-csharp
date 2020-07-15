using System;
using System.Collections.Generic;
using GenreLibrary.Models;
using GenreLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenreLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController:ControllerBase
    {
        private readonly GenreService _service;
        public GenreController(GenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
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
        public ActionResult<Genre> Get(int id)
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

        [HttpPost]
        public ActionResult<Genre> Post([FromBody] Genre newGenre)
        {
            try
            {
                return Ok(_service.Create(newGenre));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Genre> Edit([FromBody] Genre newGenre, int id)
        {
            try
            {
                newGenre.Id = id;
                return Ok(_service.Edit(newGenre));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Genre> Delete(int id)
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