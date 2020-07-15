using System;
using System.Collections.Generic;
using GenreLibrary.Models;
using GenreLibrary.Repositories;

namespace GenreLibrary.Services
{
    public class ArtistService
    {
        private readonly ArtistRepository _repo;
        public ArtistService(ArtistRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Artist> Get()
        {
            return _repo.Get();
        }

        internal Artist Get(int id)
        {
            Artist exists = _repo.GetById(id);
            if(exists == null){
                throw new Exception("Invalid Artist ID");
            }
            return exists;
        }

        internal Artist Create(Artist newArtist)
        {
            int id = _repo.Create(newArtist);
            newArtist.Id = id;
            return newArtist;
        }

        internal Artist Edit(Artist editArtist)
        {
            Artist original = Get(editArtist.Id);
            original.Name = editArtist.Name.Length > 0 ? editArtist.Name : original.Name;
            original.Description = editArtist.Description.Length > 0 ? editArtist.Description : original.Name;
            return _repo.Edit(original);
        }

        internal Artist Delete(int id)
        {
            Artist exists = Get(id);
            _repo.Delete(id);
            return exists;
        }
    }
}