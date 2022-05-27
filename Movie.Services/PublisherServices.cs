using System;
using System.Collections.Generic;
using System.Text;
using Movie.Entities;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;

namespace Movie.Services
{
    public class PublisherServices : IPublisherServices
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherServices(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void Add(Publisher publisher)
        {
            _publisherRepository.AddPublisher(publisher);
        }

        public void Delete(int publisherId)
        {
            _publisherRepository.DeletePublisher(publisherId);

        }

        public void Edit(Publisher publisher)
        {
            _publisherRepository.EditPublisher(publisher);

        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            var result = _publisherRepository.GetAllPublishers();
            return result;
        }

        public Publisher GetPublisherById(int id)
        {
            var result = _publisherRepository.GetPublisherById(id);
            return result;
        }
    }
}
