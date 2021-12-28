using Bookola.Data;
using Bookola.Models;
using Bookola.Models.GraphicNovel;
using Bookola.Models.Magazine;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookola.Services
{
    public class AuthorService
    {
        private readonly Guid _userId;
        public AuthorService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAuthor(AuthorCreate model)
        {
            var entity =
                new Author()
                {
                    UserId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors
                    .Where(e => e.UserId == _userId)
                    .AsEnumerable()
                    .Select(
                        e =>
                            new AuthorListItem
                            {
                                AuthorId = e.AuthorId,
                                FullName = e.FullName()
                            }
                        );
                return query.ToArray();
            }
        }

        public AuthorDetail GetAuthorbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == id && e.UserId == _userId);
                return

                    new AuthorDetail

                    {
                        AuthorId = entity.AuthorId,
                        FullName = entity.FullName(),
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Books = entity.Books.Select(b => new BookListItem()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            AuthorId = b.AuthorId,
                        }).ToList(),
                        Magazines = entity.Authorships.Select(b => new MagazineListItem()
                        {
                            Id = b.Magazine.Id,
                            Title = b.Magazine.Title,
                            Volume = b.Magazine.Volume,
                            IssueDate = b.Magazine.IssueDate,
                            Genre = b.Magazine.Genre.ToString()
                        }).ToList(),
                        GraphicNovelsWritten = entity.WrittenGraphicNovels.Select(g => new GraphicNovelListItem()
                        {
                            Id = g.Id,
                            Title = g.Title,
                            Volume = g.Volume,
                            IssuedDate = g.IssuedDate,
                            Genre = g.Genre.ToString()
                        }).ToList(),
                        GraphicNovelsDrawn = entity.DrawnGraphicNovels.Select(g => new GraphicNovelListItem()
                        {
                            Id = g.Id,
                            Title = g.Title,
                            Volume = g.Volume,
                            IssuedDate = g.IssuedDate,
                            Genre = g.Genre.ToString()
                        }).ToList()
                    };
            }
        }

        public AuthorDetail GetAuthorbyLastName(string lastName)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.LastName.Contains(lastName) && e.UserId == _userId);
                return

                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        FullName = entity.FullName(),
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Books = entity.Books.Select(b => new BookListItem()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            AuthorId = b.AuthorId,
                        }).ToList(),
                        Magazines = entity.Authorships.Select(b => new MagazineListItem()
                        {
                            Id = b.Magazine.Id,
                            Title = b.Magazine.Title,
                            Volume = b.Magazine.Volume,
                            IssueDate = b.Magazine.IssueDate,
                            Genre = b.Magazine.Genre.ToString()
                        }).ToList(),
                        GraphicNovelsWritten = entity.WrittenGraphicNovels.Select(g => new GraphicNovelListItem()
                        {
                            Id = g.Id,
                            Title = g.Title,
                            Volume = g.Volume,
                            IssuedDate = g.IssuedDate,
                            Genre = g.Genre.ToString()
                        }).ToList(),
                        GraphicNovelsDrawn = entity.DrawnGraphicNovels.Select(g => new GraphicNovelListItem()
                        {
                            Id = g.Id,
                            Title = g.Title,
                            Volume = g.Volume,
                            IssuedDate = g.IssuedDate,
                            Genre = g.Genre.ToString()
                        }).ToList()
                    };
            }
        }
        public bool UpdateAuthors(AuthorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == model.AuthorId && e.UserId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAuthor(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == authorId && e.UserId == _userId);
                ctx.Authors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

