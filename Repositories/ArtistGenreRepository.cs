using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using GenreLibrary.Models;

namespace GenreLibrary.Repositories
{
    public class ArtistGenreRepository
    {
        private readonly IDbConnection _db;
        public ArtistGenreRepository(IDbConnection db){
            _db = db;
        }

        // internal IEnumerable<Artist> Get()
        // {
        //     string sql = "SELECT * FROM artists";
        //     return _db.Query<Artist>(sql);
        // }

        internal DTOArtistGenre GetById(int id)
        {
            string sql = @"
                SELECT * FROM artistgenre
                WHERE id = @id";
            return _db.QueryFirstOrDefault<DTOArtistGenre>(sql, new { id });
        }

        internal IEnumerable<ArtistGenre> GetGenreByArtistId(int id)
        {
            string sql = @"
                SELECT
                    i.*,
                    ag.id as ArtistGenreId
                FROM artistgenre ag
                INNER JOIN genre i ON i.id = ag.genreId
                WHERE(ag.artistId = @id)
                ";
            return _db.Query<ArtistGenre>(sql, new { id });
        }

        internal int Create(DTOArtistGenre newArtistGenre)
        {
            string sql = @"
                INSERT INTO artistgenre
                (artistId, genreId)
                VALUES
                (@ArtistId, @GenreId);
                SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newArtistGenre);
        }


        internal void Delete(int id)
        {
            string sql = "DELETE FROM artistgenre WHERE id = @Id";
            _db.Execute(sql, new { id });
        }
    }
}