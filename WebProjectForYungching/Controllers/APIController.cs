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
            return Json(_albumService.Query());
        }
    }
}