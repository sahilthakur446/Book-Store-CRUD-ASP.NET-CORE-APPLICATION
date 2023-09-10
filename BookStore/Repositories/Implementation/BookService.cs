using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;
using Humanizer.Localisation;
using System.Security.Policy;

namespace BookStore.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext context;

        public BookService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Book model)
        {
            context.Book.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Book model)
        {

            context.Book.Remove(model);
            context.SaveChanges();
            return true;

        }

        public Book FindById(int id)
        {
            return context.Book.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in context.Book
                        join author in context.Author
                        on book.AuthorId equals author.Id
                        join publisher in context.Publisher on book.PublisherId equals publisher.Id
                        join genre in context.Genre on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            GenreId = book.GenreId,
                            ISBN = book.ISBN,
                            PublisherId = book.PublisherId,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PublisherName
                        }
                        ).ToList();
            return data;
           
        }

        public bool Update(Book model)
        {
            context.Book.Update(model);
            context.SaveChanges();
            return true;
        }
    }
}
