using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Repository.Interfaces
{
    public interface IPublisherRepository
    {
        void AddPublisher(Publisher publisher);
        void EditPublisher(Publisher publisher);
        void DeletePublisher(int publisherId);
        Publisher GetPublisherById(int id);
        IEnumerable<Publisher> GetAllPublishers();
    }
}