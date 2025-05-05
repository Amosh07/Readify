using Readify.DTOs.Publisher;
using System.Collections.Generic;

namespace Readify.Service.Interface
{
    public interface IPublisherService
    {
        void AddPublisher(InsertPublisherDto publisherDto);

        List<GetAllPublisher> GetAllPublishers();

        GetAllPublisher GetById(int id);

        void DeletePublisher(int id);

        void UpdatePublisher(int id, UpdatePublisherDto publisherDto);
    }
}
