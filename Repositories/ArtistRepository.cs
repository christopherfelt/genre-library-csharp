using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using GenreLibrary.Models;

namespace GenreLibrary.Repositories
{
    public class ArtistRepository
    {
        private readonly IDbConnection _db;
        public ArtistRepository(IDbConnection db){
            _db = db;
        }

        internal IEnumerable<Artist> Get()
        {
            string sql = "SELECT * FROM artists";
            return _db.Query<Artist>(sql);
        }

        internal Artist GetById(int id)
        {
            string sql = @"
                SELECT * FROM artists
                WHERE id = @id";
            return _db.QueryFirstOrDefault<Artist>(sql, new { id });
        }

        internal int Create(Artist newArtist)
        {
            string sql = @"
                INSERT INTO artists
                (name, description)
                VALUES
                (@Name, @Description);
                SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newArtist);
        }



        internal Artist Edit(Artist original)
        {
            string sql = @"
            UPDATE artists
            SET
                name = @Name,
                description = @Description
            WHERE id = @id;
            SELECT * FROM artists WHERE id = @id;";
            return _db.QueryFirstOrDefault<Artist>(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM artists WHERE id = @Id";
            _db.Execute(sql, new { id });
        }
    }
}