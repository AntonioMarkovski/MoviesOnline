using System;
using System.Collections.Generic;
using System.Text;
using Movie.Entities;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;

namespace Movie.Services
{
    public class DirectorServices : IDirectorServices
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorServices(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public void Add(Director director)
        {
            _directorRepository.AddDirector(director);
        }

        public void Delete(int directorId)
        {
            _directorRepository.DeleteDirector(directorId);
        }

        public void Edit(Director director)
        {
            _directorRepository.EditDirector(director);
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            var result = _directorRepository.GetAllDirectors();
            return result;
        }

        public Director GetAuthorById(int id)
        {
            var result = _directorRepository.GetDirectorById(id);
            return result;
        }
    }
}
