using Movie.Data;
using Movie.Entities;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly DataContext _dataContext;

        public PublisherRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddPublisher(Publisher publisher)
        {
            _dataContext.Publisher.Add(publisher);
            _dataContext.SaveChanges();
        }

        public void DeletePublisher(int publisherId)
        {
            Publisher publisher = GetPublisherById(publisherId);
            _dataContext.Publisher.Remove(publisher);
            _dataContext.SaveChanges();
        }

        public void EditPublisher(Publisher publisher)
        {
            _dataContext.Publisher.Update(publisher);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            var result = _dataContext.Publisher.AsEnumerable();
            return result;
        }

        public Publisher GetPublisherById(int id)
        {
            var result = _dataContext.Publisher.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
