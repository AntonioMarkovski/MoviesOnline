using System;
using System.Text;
using Movie.Entities;
using System.Collections.Generic;

namespace Movie.Services.Interfaces
{
    public interface IPublisherServices
    {
        void Add(Publisher publisher);
        void Edit(Publisher publisher);
        void Delete(int publisherId);
        Publisher GetPublisherById(int id);
        IEnumerable<Publisher> GetAllPublishers();
    }
}