using DBLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjectForYungching.Services.Interfaces;

namespace WebProjectForYungching.Controllers
{
    public class APIController : Controller
    {
        private IAlbumService _albumService;

        public APIController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        // GET: API
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllAlbum()
        {
            return Json(_albumService.Query(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAlbum(Album album)
        {
            album.AlbumID = _albumService.Query().Count + 1;
            _albumService.Add(album);
            return Content("OK");
        }

        public ActionResult UpdateAlbum(Album album)
        {
            _albumService.Update(album);
            return Content("OK");
        }
    }
}