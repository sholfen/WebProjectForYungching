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
        private AlbumRepository repository;
        public AlbumService()
        {
            repository = new AlbumRepository();
        }

        public List<Album> Query()
        {
            List<Album> list = repository.Query();

            return list;
        }

        public void Add(Album album)
        {
            repository.Insert(album);
        }

        public void Update(Album album)
        {
            repository.Update(album);
        }
    }
}