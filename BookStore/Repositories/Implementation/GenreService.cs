using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext context;

        public GenreService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Genre model)
        {
            context.Genre.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Genre model)
        {
            
            context.Genre.Remove(model);
            context.SaveChanges();
            return true;

        }

        public Genre FindById(int id)
        {
            return context.Genre.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genre.ToList();
        }
        
        public bool Update(Genre model)
        {
            context.Genre.Update(model);
            context.SaveChanges();
            return true;
        }
        public string FindGenreNamebyId(int id)
        {
            var x = context.Genre.FirstOrDefault(x => x.Id == id);
            return x.Name;
        }
    }
}
