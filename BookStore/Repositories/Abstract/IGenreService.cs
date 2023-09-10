using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        bool Delete(Genre model);
        Genre FindById(int id);
        string FindGenreNamebyId(int id);
        IEnumerable<Genre> GetAll();
    }
}
