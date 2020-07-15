using System;
using System.Collections.Generic;
using GenreLibrary.Models;
using GenreLibrary.Repositories;

namespace GenreLibrary.Services
{
    public class GenreService
    {
        private readonly GenreRepository _repo;
        public GenreService(GenreRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Genre> Get()
        {
            return _repo.Get();
        }

        internal Genre Get(int id)
        {
            Genre exists = _repo.GetById(id);
            if(exists == null){
                throw new Exception("Invalid Genre ID");
            }
            return exists;
        }

        internal Genre Create(Genre newGenre)
        {
            int id = _repo.Create(newGenre);
            newGenre.Id = id;
            return newGenre;
        }

        internal Genre Edit(Genre editGenre)
        {
            Genre original = Get(editGenre.Id);
            original.Name = editGenre.Name.Length > 0 ? editGenre.Name : original.Name;
            original.Description = editGenre.Description.Length > 0 ? editGenre.Description : original.Name;
            return _repo.Edit(original);
        }

        internal Genre Delete(int id)
        {
            Genre exists = Get(id);
            _repo.Delete(id);
            return exists;
        }
    }
}