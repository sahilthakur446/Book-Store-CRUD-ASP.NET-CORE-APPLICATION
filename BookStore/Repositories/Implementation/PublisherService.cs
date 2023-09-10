using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly DatabaseContext context;

        public PublisherService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Publisher model)
        {
            context.Publisher.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Publisher model)
        {

            context.Publisher.Remove(model);
            context.SaveChanges();
            return true;

        }

        public Publisher FindById(int id)
        {
            return context.Publisher.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return context.Publisher.ToList();
        }

        public bool Update(Publisher model)
        {
            context.Publisher.Update(model);
            context.SaveChanges();
            return true;
        }
        public string FindPublicationNamebyId(int id)
        {
            var result = context.Publisher.FirstOrDefault(x => x.Id == id);
            return result.PublisherName;
        }

    }
}
