using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class Album
    {
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
    }
}
