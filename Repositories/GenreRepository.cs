using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using GenreLibrary.Models;

namespace GenreLibrary.Repositories
{
    public class GenreRepository
    {
        private readonly IDbConnection _db;
        public GenreRepository(IDbConnection db){
            _db = db;
        }

        internal IEnumerable<Genre> Get()
        {
            string sql = "SELECT * FROM genre";
            return _db.Query<Genre>(sql);
        }

        internal Genre GetById(int id)
        {
            string sql = @"
                SELECT * FROM genre
                WHERE id = @id";
            return _db.QueryFirstOrDefault<Genre>(sql, new { id });
        }

        internal int Create(Genre newGenre)
        {
            string sql = @"
                INSERT INTO genre
                (name, description)
                VALUES
                (@Name, @Description);
                SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newGenre);
        }



        internal Genre Edit(Genre original)
        {
            string sql = @"
            UPDATE genre
            SET
                name = @Name,
                description = @Description
            WHERE id = @id;
            SELECT * FROM genre WHERE id = @id;";
            return _db.QueryFirstOrDefault<Genre>(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM genre WHERE id = @Id";
            _db.Execute(sql, new { id });
        }
    }
}