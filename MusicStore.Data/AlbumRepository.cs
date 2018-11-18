using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class AlbumRepository
    {
        public static IList<Album> GetAlbumsByGenre(int genreId)
        {
            var albums = new List<Album>();



            string selectAlbums = "SELECT ArtistId, Title, Price, AlbumArtUrl FROM Album WHERE GenreId = @GenreId ORDER BY Title";

            SqlConnection connection = MusicStoreDB.GetSqlConnection();

            SqlCommand selectCommand = new SqlCommand
            {
                CommandText = selectAlbums,
                Connection = connection
            };
            selectCommand.Parameters.AddWithValue("@GenreId", genreId);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Album album = new Album
                    {
                        Title = reader["Title"].ToString(),
                        ArtistId = (int)reader["ArtistId"],
                        Price = (decimal)reader["Price"],
                        AlbumArtUrl = reader["AlbumArtUrl"].ToString()
                    };
                    albums.Add(album);
                }

            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return albums;
        }
    }
}
