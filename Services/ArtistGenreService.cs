using System;
using System.Collections.Generic;
using GenreLibrary.Models;
using GenreLibrary.Repositories;

namespace GenreLibrary.Services
{
    public class ArtistGenreService
    {
        private readonly ArtistGenreRepository _repo;
        public ArtistGenreService(ArtistGenreRepository repo)
        {
            _repo = repo;
        }

        public DTOArtistGenre Get(int Id)
        {
            DTOArtistGenre exists = _repo.GetById(Id);
            if(exists == null){
                throw new Exception("Invalid ArtistGenre Id");
            }
            return exists;
        }

        internal IEnumerable<ArtistGenre> GetGenreByArtistId(int id)
        {
            return _repo.GetGenreByArtistId(id);
        }

        internal DTOArtistGenre Create(DTOArtistGenre newArtistGenre)
        {
            int id = _repo.Create(newArtistGenre);
            newArtistGenre.Id = id;
            return newArtistGenre;
        }

        internal object Delete(int id)
        {
            DTOArtistGenre exists = Get(id);
            _repo.Delete(id);
            return exists;
        }


    }
}