using Dapper;
using DBLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Repositories
{
    public class AlbumRepository : BaseRepository<Album>
    {
        //public AlbumRepository() : base(@"Data Source=.\App_Data\sample.sqlite;")
        public AlbumRepository() : base(@"Data Source=C:\sample.sqlite;")
        {

        }

        public void Update(Album album)
        {
            string query =
                $"UPDATE Album SET Title = @Title, ArtistId = @ArtistId WHERE AlbumID = @AlbumID";
            _sqlConnection.Execute(query, album);
        }

        public void Delete(Album album)
        {
            string query =
                $"DELETE FROM Album WHERE AlbumID = @AlbumID;";
            _sqlConnection.Execute(query, album);
        }
    }
}
