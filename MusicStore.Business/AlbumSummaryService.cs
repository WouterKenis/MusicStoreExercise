using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Business
{
    public class AlbumSummaryService
    {
        public static IList<AlbumSummary> GetAlbumSummariesByGenre(int genreId)
        {
            var albumSummary = new List<AlbumSummary>();
            IList<Album> albumList = new List<Album>();

            albumList = AlbumRepository.GetAlbumsByGenre(genreId);

            for (int i = 0; i < albumList.Count; i++)
            {
                albumSummary.Add(new AlbumSummary
                {
                    Artist = ArtistRepository.GetArtistNameById(albumList.ElementAt(i).ArtistId).Name,
                    Title = albumList.ElementAt(i).Title,
                    Price = albumList.ElementAt(i).Price.ToString()
                });
            }
            return albumSummary;
        } 
    }
}
