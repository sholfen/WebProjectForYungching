using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBLib.Models;
using DBLib.Repositories;
using WebProjectForYungching.Services.Interfaces;

namespace WebProjectForYungching.Services.Implements
{
    public class AlbumService : IAlbumService
    {
        private BaseRepository<Album> repository;
        public AlbumService()
        {
            repository = new AlbumRepository();
        }

        public List<Album> Query()
        {
            List<Album> list = new List<Album>();

            return list;
        }
    }
}