using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly DatabaseContext context;

        public AuthorService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Author model)
        {
            context.Author.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Author model)
        {

            context.Author.Remove(model);
            context.SaveChanges();
            return true;

        }

        public Author FindById(int id)
        {
            return context.Author.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return context.Author.ToList();
        }
        public string GetAuthorNameById(int authorId)
        {
            var author = context.Author.FirstOrDefault(x => x.Id == authorId);
            return author?.AuthorName;
        }
        public bool Update(Author model)
        {
            context.Author.Update(model);
            context.SaveChanges();
            return true;
        }
    }
}
