﻿using Bookola.Models.Genre;
using Bookola.Service;
using Microsoft.AspNet.Identity;
using Bookola.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookola.Services.GenreService;

namespace Bookola.WebAPI.Controllers.GenreController
{
    [Authorize]
    public class GenreController : ApiController
    {
        private GenreService CreateGenreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var genreService = new GenreService(userId);
            return genreService;
        }
        [Route("api/Genre/Create")]
        public IHttpActionResult Post(GenreCreate genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateGenreService();
            if (!service.CreateGenre(genre))
            {
                return InternalServerError();
            }
            return Ok("Genre was added!");
        }
        [Route("api/Genre/GetAll")]
        public IHttpActionResult Get()
        {
            GenreService genreService = CreateGenreService();
            var genres = genreService.GetGenres();
            return Ok(genres);
        }
        [Route("api/Genre/GetById")]
        public IHttpActionResult Get(int id)
        {
            GenreService genreService = CreateGenreService();
            var genre = genreService.GetGenrebyId(id);
            return Ok(genre);
        }
        [Route("api/Genre/GetByName")]
        public IHttpActionResult Get(string name)
        {
            GenreService genreService = CreateGenreService();
            var genre = genreService.GetGenrebyName(name);
            return Ok(genre);
        }

        [Route("api/Genre/Update")]
        public IHttpActionResult Put(GenreEdit genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateGenreService();
            if (!service.UpdateGenres(genre))
            {
                return InternalServerError();
            }
            return Ok("Genre was updated!");
        }
        [Route("api/Genre/Delete{id}")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGenreService();
            if (!service.DeleteGenre(id))
            {
                return InternalServerError();
            }
            return Ok("Genre was deleted!");
        }
    }
}