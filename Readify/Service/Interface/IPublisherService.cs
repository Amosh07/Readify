using Readify.DTOs.Publisher;
using System.Collections.Generic;

namespace Readify.Service.Interface
{
    public interface IPublisherService
    {
        void AddPublisher(InsertPublisherDto publisherDto);

        List<GetAllPublisher> GetAllPublishers();

        GetAllPublisher GetById(Guid id);

        void DeletePublisher(Guid id);

        void UpdatePublisher(Guid id, UpdatePublisherDto publisherDto);
    }
}
