using Bookola.Data;
using Bookola.Models;
using Bookola.Models.Book;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pubola.Services
{
    public class BookService
    {
        private readonly Guid _userId;
        public BookService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    UserId = _userId,
                    Title = model.Title,
                    Isbn = model.Isbn,
                    AuthorId = model.AuthorId,
                    Genre = model.Genre
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateBookAndAuthor(BookAndAuthorCreate model)
        {
            var entity =
                new Book()
                {
                    UserId = _userId,
                    Title = model.Title,
                    Isbn = model.Isbn,
                    Genre = model.Genre
                };
            var author = new Author()
            {
                FirstName = model.AuthorFirstName,
                LastName = model.AuthorLastName,
                UserId = _userId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(author);
                // Make sure author saved before going forward
                if (ctx.SaveChanges() == 1)
                {
                    var savedAuthor = ctx.Authors.OrderByDescending(x => x.AuthorId).FirstOrDefault();
                    entity.AuthorId = savedAuthor.AuthorId;
                    ctx.Books.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                            new BookListItem
                            {
                                Id = e.Id,
                                Title = e.Title,
                                AuthorId = e.AuthorId
                            }
                        );
                return query.ToArray();
            }
        }
        public BookDetail GetBookbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = new AuthorListItem()
                        {
                            AuthorId = entity.AuthorId,
                            FullName = entity.Author.FullName(),
                        },
                        Isbn = entity.Isbn,
                        Genre = entity.Genre.ToString()
                    };
            }
        }
        public IEnumerable<BookListItem> GetBooksByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books
                    .Where(e => e.Title == title && e.UserId == _userId)
                    .Select(
                        e =>
                            new BookListItem
                            {
                                Id = e.Id,
                                Title = e.Title,
                                AuthorId = e.AuthorId
                            }
                        );
                return query.ToArray();
            }
        }
        public BookDetail GetBookbyAuthor(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.AuthorId == authorId && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = new AuthorListItem()
                        {
                            AuthorId = entity.AuthorId,
                            FullName = entity.Author.FullName(),
                        },
                        Isbn = entity.Isbn,
                        Genre = entity.Genre.ToString()
                    };
            }
        }
        public BookDetail GetBookbyIsbn(long isbn)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Isbn == isbn && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Author = new AuthorListItem()
                        {
                            AuthorId = entity.AuthorId,
                            FullName = entity.Author.FullName(),
                        },
                        Isbn = entity.Isbn,
                        Genre = entity.Genre.ToString()
                    };
            }
        }
        public bool UpdateBooks(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Title = model.Title;
                entity.Isbn = model.Isbn;
                entity.AuthorId = model.AuthorId;
                entity.Genre = model.Genre;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBook(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == id && e.UserId == _userId);
                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}