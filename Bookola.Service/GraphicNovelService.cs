using Bookola.Data;
using Bookola.Models;
using Bookola.Models.GraphicNovel;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookola.Service
{
    public class GraphicNovelService
    {
        private readonly Guid _userId;

        public GraphicNovelService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGraphicNovel(GraphicNovelCreate Model)
        {
            var entity = new GraphicNovel()
            {
                UserId = _userId,
                Title = Model.Title,
                Volume = Model.Volume,
                Isbn = Model.Isbn,
                IssuedDate = Model.IssuedDate,
                Genre = Model.Genre,
                WriterId = Model.WriterId,
                ArtistId = Model.ArtistId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GraphicNovels.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GraphicNovelListItem> GetGraphicNovel()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GraphicNovels
                        .Where(e => e.UserId == _userId)
                        .AsEnumerable()
                        .Select(
                            e =>
                                new GraphicNovelListItem
                                {
                                    Id = e.Id,
                                    Title = e.Title,
                                    Volume = e.Volume,
                                    IssuedDate = e.IssuedDate,
                                    Genre = e.Genre.ToString()
                                }
                        );
                return query.ToArray();
            }
        }

        public GraphicNovelDetail GetGraphicNovelById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new GraphicNovelDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Volume = entity.Volume,
                        Isbn = entity.Isbn,
                        IssuedDate = entity.IssuedDate,
                        Genre = entity.Genre.ToString(),
                        Writer = new AuthorListItem()
                        {
                            AuthorId = entity.WriterId,
                            FullName = entity.Writer.FullName(),
                        },
                        Artist = new AuthorListItem()
                        {
                            AuthorId = entity.ArtistId,
                            FullName = entity.Artist.FullName(),
                        }
                    };
            }
        }

        public bool UpdateGraphicNovel(GraphicNovelEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Id == model.Id && e.UserId == _userId);


                entity.Title = model.Title;
                entity.Isbn = model.Isbn;
                entity.Volume = model.Volume;
                entity.IssuedDate = model.IssuedDate;
                entity.Genre = model.Genre;
                entity.ArtistId = model.ArtistId;
                entity.WriterId = model.WriterId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGraphicNovel(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GraphicNovels
                        .Single(e => e.Id == Id && e.UserId == _userId);
                ctx.GraphicNovels.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
