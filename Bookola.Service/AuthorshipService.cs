using Bookola.Data;
using Bookola.Models;
using Bookola.Models.Authorship;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookola.Services
{
    public class AuthorshipService
    {
        private readonly Guid _userId;
        public AuthorshipService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAuthorship(AuthorshipCreate model)
        {
            var entity =
                new Authorship()
                {
                    AuthorId=model.AuthorId,
                    MagazineId=model.MagazineId,
                    UserId = _userId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authorships.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AuthorshipListItem> GetAuthorships()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authorships.Where(x => x.UserId == _userId).AsEnumerable()
                    .Select(
                        e =>
                            new AuthorshipListItem
                            {
                                AuthorId = e.AuthorId,
                                Author = e.Author.FullName(),
                                MagazineId = e.MagazineId,
                                MagazineTitle = e.Magazine.Title
                            }
                        );
                return query.ToArray();
            }
        }

        public AuthorshipDetail GetAuthorshipbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authorships
                        .Single(e => e.Id == id && e.UserId == _userId);
                return

                    new AuthorshipDetail

                    {
                        Id = entity.Id,
                        AuthorId = entity.AuthorId,
                        Author = entity.Author.FullName(),
                        Magazine = new Models.Magazine.MagazineDetail()
                        {
                            Id = entity.Magazine.Id,
                            Title = entity.Magazine.Title,
                            Volume = entity.Magazine.Volume,
                            IssueDate = entity.Magazine.IssueDate,
                            Authors = entity.Magazine.Authors.Select(x => x.Author.FullName()).ToList(),
                            Genre = entity.Magazine.Genre.ToString()
                        }
                    };
            }
        }

        public bool UpdateAuthorships(AuthorshipEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authorships
                        .Single(e => e.Id == model.Id && e.UserId == _userId);

                entity.AuthorId = model.AuthorId;
                entity.MagazineId = model.MagazineId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAuthorship(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authorships
                        .Single(e => e.Id == authorId && e.UserId == _userId);
                ctx.Authorships.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

