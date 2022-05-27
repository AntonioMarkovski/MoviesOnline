using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;


namespace Movie.Services.Interfaces
{
    public interface IDirectorServices
    {
        void Add(Director director);
        void Edit(Director director);
        void Delete(int directorId);
        Director GetAuthorById(int id);
        IEnumerable<Director> GetAllDirectors();
    }
}