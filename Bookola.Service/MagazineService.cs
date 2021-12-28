using Bookola.Data;
using Bookola.Models.Magazine;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookola.Service
{
    public class MagazineService
    {
        private readonly Guid _userId;

        public MagazineService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMagazine(MagazineCreate model)
        {
            var entity = new Magazine
            {
                UserId = _userId,
                Title = model.Title,
                Volume = model.Volume,
                IssueDate = model.IssueDate,
                Genre = model.Genre
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Magazines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MagazineListItem> GetMagazines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Magazines
                    .Where(e => e.UserId == _userId)
                    .AsEnumerable()
                    .Select(
                        e =>
                        new MagazineListItem
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Volume = e.Volume,
                            Genre = e.Genre.ToString()
                        });
                return query.ToArray();
            }
        }

        public MagazineDetail GetMagazineById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                    .Magazines
                    .Single(e => e.Id == id && e.UserId == _userId);
                return new MagazineDetail
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Volume = entity.Volume,
                    Genre = entity.Genre.ToString(),
                    Authors = entity.Authors.Select(e => e.Author.FullName()).ToList()
                };
            }
        }

        public MagazineDetail GetMagazineByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Title.Contains(title) && e.UserId == _userId);
                return new MagazineDetail
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Volume = entity.Volume,
                    Genre = entity.Genre.ToString(),
                    Authors = entity.Authors.Select(e => e.Author.FullName()).ToList()
                };
            }
        }
        public object GetMagazineByVolume(int volume)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                     .Magazines
                     .Where(e => e.Volume == volume && e.UserId == _userId)
                     .AsEnumerable()
                     .Select(
                         e =>
                         new MagazineListItem
                         {
                             Id = e.Id,
                             Title = e.Title,
                             Volume = e.Volume,
                             Genre = e.Genre.ToString()
                         });
                return query.ToArray();
            }
        }
        public object GetMagazineByIssueDate(DateTime issueDate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                     .Magazines
                     .Where(e => e.IssueDate == issueDate && e.UserId == _userId)
                     .AsEnumerable()
                     .Select(
                         e =>
                         new MagazineListItem
                         {
                             Id = e.Id,
                             Title = e.Title,
                             Volume = e.Volume,
                             IssueDate = e.IssueDate,
                             Genre = e.Genre.ToString()
                         });
                return query.ToArray();
            }
        }

        public object GetMagazineByGenre(MagazineGenre genre)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                     .Magazines
                     .Where(e => e.Genre == genre && e.UserId == _userId)
                     .AsEnumerable()
                     .Select(
                         e =>
                         new MagazineListItem
                         {
                             Id = e.Id,
                             Title = e.Title,
                             Volume = e.Volume,
                             IssueDate = e.IssueDate,
                             Genre = e.Genre.ToString()
                         });
                return query.ToArray();

            }
        }
        public bool UpdateMagazines(MagazineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Title = model.Title;
                entity.Volume = model.Volume;
                entity.Genre = model.Genre;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMagazine(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Id == Id && e.UserId == _userId);
                ctx.Magazines.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteMagazineByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Title == title && e.UserId == _userId);
                ctx.Magazines.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}


