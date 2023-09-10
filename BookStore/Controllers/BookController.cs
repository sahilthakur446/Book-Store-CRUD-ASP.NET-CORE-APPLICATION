using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookservice;
        private readonly IAuthorService authorservice;
        private readonly IGenreService genreservice;
        private readonly IPublisherService publisherservice;

        public BookController(IBookService bookservice, IAuthorService authorservice,IGenreService genreservice,IPublisherService publisherservice)
        {
            this.bookservice = bookservice;
            this.authorservice = authorservice;
            this.genreservice = genreservice;
            this.publisherservice = publisherservice;
        }
        public IActionResult Add()
        {
            var model = new Book();
            model.AuthorList = authorservice.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString() }).ToList();
            model.PublisherList = publisherservice.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString() }).ToList();
            model.GenreList = genreservice.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AuthorList = authorservice.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(),Selected=a.Id==model.AuthorId }).ToList();
            model.PublisherList = publisherservice.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreservice.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookservice.Add(model);
            if (result == true)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured";
            return View();
        }
        public IActionResult Update(int id)
        {
            var model = bookservice.FindById(id);
            model.AuthorList = authorservice.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherservice.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreservice.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthorList = authorservice.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherservice.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreservice.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookservice.Update(model);
            if (result == true)
            {
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured";
            return View();
        }

        public IActionResult Delete(int id)
        {

            var model = bookservice.FindById(id);
            model.AuthorName = authorservice.GetAuthorNameById(model.AuthorId);
            model.GenreName = genreservice.FindGenreNamebyId(model.GenreId);
            model.PublisherName = publisherservice.FindPublicationNamebyId(model.PublisherId);

            model.AuthorList = authorservice.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherservice.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreservice.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Book model)
        {
            var result = bookservice.Delete(model);
            if (result == true)
            {

                return RedirectToAction("GetAll");
            }
            return View();
        }
        public IActionResult GetAll()
        {
            var x = bookservice.GetAll();
            return View(x);
        }
    }
}

