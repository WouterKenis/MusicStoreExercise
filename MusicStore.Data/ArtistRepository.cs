using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class ArtistRepository
    {
        public static Artist GetArtistNameById(int artistId)
        {
            Artist artist = null;

            string selectAlbums = "SELECT Name FROM Artist WHERE ArtistId = @ArtistId";

            SqlConnection connection = MusicStoreDB.GetSqlConnection();

            SqlCommand selectCommand = new SqlCommand
            {
                CommandText = selectAlbums,
                Connection = connection
            };
            selectCommand.Parameters.AddWithValue("@ArtistId", artistId);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    artist = new Artist
                    {
                        Name = reader["Name"].ToString(),
                    };
                    

                }

            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }

            return artist;
        }
    }
}
