﻿using Bookola.Models.GraphicNovel;
using Bookola.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace Bookola.WebAPI.Controllers
{
    [Authorize]
    public class GraphicNovelController : ApiController
    {
        private GraphicNovelService CreateGraphicNovelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new GraphicNovelService(userId);
            return commentService;
        }

        public IHttpActionResult Get()
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovels = graphicNovelService.GetGraphicNovel();
            return Ok(graphicNovels);
        }

        public IHttpActionResult Post(GraphicNovelCreate graphicNovel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGraphicNovelService();

            if (!service.CreateGraphicNovel(graphicNovel))
                return InternalServerError();

            return Ok();

        }

        public IHttpActionResult Get(int id)
        {
            GraphicNovelService graphicNovelService = CreateGraphicNovelService();
            var graphicNovel = graphicNovelService.GetGraphicNovelById(id);
            return Ok();
        }

        public IHttpActionResult Put(GraphicNovelEdit graphicNovel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGraphicNovelService();

            if (!service.UpdateGraphicNovel(graphicNovel))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateGraphicNovelService();

            if (!service.DeleteGraphicNovel(id))
                return InternalServerError();

            return Ok();
        }
    }
}
