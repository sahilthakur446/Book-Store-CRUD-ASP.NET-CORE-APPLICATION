using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract
{
    public interface IPublisherService
    {
        bool Add(Publisher model);
        bool Update(Publisher model);
        bool Delete(Publisher model);
        Publisher FindById(int id);
        IEnumerable<Publisher> GetAll();
        string FindPublicationNamebyId(int id);
    }
}
