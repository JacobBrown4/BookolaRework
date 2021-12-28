using Bookola.Models;
using Bookola.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace Bookola.WebAPI.Controllers.AuthorController
{
    [Authorize]
    public class AuthorController : ApiController
    {
        private AuthorService CreateAuthorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new AuthorService(userId);
            return bookService;
        }
        
        [Route("api/Author/Create")]
        public IHttpActionResult Post(AuthorCreate book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateAuthorService();
            if (!service.CreateAuthor(book))
            {
                return InternalServerError();
            }
            return Ok("Author was added!");
        }
        [Route("api/Author/GetAll")]
        public IHttpActionResult Get()
        {
            AuthorService bookService = CreateAuthorService();
            var books = bookService.GetAuthors();
            return Ok(books);
        }
        [Route("api/Author/GetById")]
        public IHttpActionResult GetById(int id)
        {
            AuthorService bookService = CreateAuthorService();
            var book = bookService.GetAuthorbyId(id);
            return Ok(book);
        }
        [Route("api/Author/GetByLastName")]
        public IHttpActionResult GetByLast(string lastName)
        {
            AuthorService bookService = CreateAuthorService();
            var book = bookService.GetAuthorbyLastName(lastName);
            return Ok(book);
        }
        [Route("api/Author/Update")]
        public IHttpActionResult Put(AuthorEdit book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateAuthorService();
            if (!service.UpdateAuthors(book))
            {
                return InternalServerError();
            }
            return Ok("Author has been updated!");
        }
        [Route("api/Author/DeleteById")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAuthorService();
            if (!service.DeleteAuthor(id))
            {
                return InternalServerError();
            }
            return Ok("Author has been deleted!");
        }
    }
}