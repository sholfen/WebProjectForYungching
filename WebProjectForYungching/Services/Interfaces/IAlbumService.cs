﻿using DBLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectForYungching.Services.Interfaces
{
    public interface IAlbumService
    {
        List<Album> Query();
    }
}
