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
        public AlbumRepository() : base(@"Data Source=.\App_Data\sample.sqlite;")
        {

        }
    }
}
