using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Repository.Interfaces
{
    public interface IDirectorRepository
    {
        void AddDirector(Director director);
        void EditDirector(Director director);
        void DeleteDirector(int directorId);
        Director GetDirectorById(int id);
        IEnumerable<Director> GetAllDirectors();
    }
}