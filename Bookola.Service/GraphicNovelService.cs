﻿using Bookola.Data;
using Bookola.Models.GraphicNovel;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
<<<<<<< HEAD
                FullName = Model.FullName,
                ReadingLevel = Model.ReadingLevel,
                GenreId = Model.GenreId,
=======
                LastName = Model.LastName,
                ReadingLevel = Model.ReadingLevel,
                GenreName = Model.GenreName,
>>>>>>> a5aabd4 (Added Author Controller)

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
                        .Select(
                            e =>
                                new GraphicNovelListItem
                                {
                                    Id = e.Id,
<<<<<<< HEAD
                                    FullName = e.FullName,
                                    Title = e.Title,
=======
                                    LastName = e.LastName,
                                    Title = e.Title,
                                    GenreName = e.GenreName,
>>>>>>> a5aabd4 (Added Author Controller)
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
