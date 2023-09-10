using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract
{
    public interface IAuthorService
    {
        bool Add(Author model);
        bool Update(Author model);
        bool Delete(Author model);
        Author FindById(int id);
        public string GetAuthorNameById(int authorId);
        IEnumerable<Author> GetAll();
    }
}
