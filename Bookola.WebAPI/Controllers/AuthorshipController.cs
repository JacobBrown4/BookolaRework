using Bookola.Models;
using Bookola.Models.Authorship;
using Bookola.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace Bookola.WebAPI.Controllers.AuthorshipController
{
    [Authorize]
    public class AuthorshipController : ApiController
    {
        private AuthorshipService CreateAuthorshipService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new AuthorshipService(userId);
            return bookService;
        }

        [Route("api/Authorship/Create")]
        public IHttpActionResult Post(AuthorshipCreate book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateAuthorshipService();
            if (!service.CreateAuthorship(book))
            {
                return InternalServerError();
            }
            return Ok("Authorship was added!");
        }
        [Route("api/Authorship/GetAll")]
        public IHttpActionResult Get()
        {
            AuthorshipService bookService = CreateAuthorshipService();
            var books = bookService.GetAuthorships();
            return Ok(books);
        }
        [Route("api/Authorship/GetById")]
        public IHttpActionResult GetById(int id)
        {
            AuthorshipService bookService = CreateAuthorshipService();
            var book = bookService.GetAuthorshipbyId(id);
            return Ok(book);
        }
        [Route("api/Authorship/Update")]
        public IHttpActionResult Put(AuthorshipEdit book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateAuthorshipService();
            if (!service.UpdateAuthorships(book))
            {
                return InternalServerError();
            }
            return Ok("Authorship has been updated!");
        }
        [Route("api/Authorship/DeleteById")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAuthorshipService();
            if (!service.DeleteAuthorship(id))
            {
                return InternalServerError();
            }
            return Ok("Authorship has been deleted!");
        }
    }
}