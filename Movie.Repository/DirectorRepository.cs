using Movie.Data;
using Movie.Entities;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DataContext _dataContext;

        public DirectorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddDirector(Director director)
        {
            _dataContext.Directors.Add(director);
            _dataContext.SaveChanges();
        }

        public void DeleteDirector(int directorId)
        {
            Director director = GetDirectorById(directorId);
            _dataContext.Directors.Remove(director);
            _dataContext.SaveChanges();
        }

        public void EditDirector(Director director)
        {
            _dataContext.Directors.Update(director);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            var result = _dataContext.Directors.AsEnumerable();
            return result;
        }

        public Director GetDirectorById(int id)
        {
            var result = _dataContext.Directors.FirstOrDefault(x => x.Id == id);
            return result;
        }

    }
}
