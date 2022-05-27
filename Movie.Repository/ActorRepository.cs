using Movie.Data;
using Movie.Entities;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly DataContext _dataContext;

        public ActorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddActor(Actor Actor)
        {
            _dataContext.Actors.Add(Actor);
            _dataContext.SaveChanges();
        }

        public void DeleteActor(int ActorId)
        {
            Actor Actor = GetActorById(ActorId);
            _dataContext.Actors.Remove(Actor);
            _dataContext.SaveChanges();
        }

        public void EditActor(Actor Actor)
        {
            _dataContext.Actors.Update(Actor);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Actor> GetAllActors()
        {
            var result = _dataContext.Actors.AsEnumerable();
            return result;
        }

        public Actor GetActorById(int id)
        {
            var result = _dataContext.Actors.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
