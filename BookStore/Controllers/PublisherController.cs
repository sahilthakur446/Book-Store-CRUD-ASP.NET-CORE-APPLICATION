using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService service;

        public PublisherController(IPublisherService service)
        {
            this.service = service;
        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Add(model);
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
            var record = service.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
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
            var result = service.FindById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Publisher model)
        {
            var result = service.Delete(model);
            if (result == true)
            {

                return RedirectToAction("GetAll");
            }
            return View();
        }
        public IActionResult GetAll()
        {
            var x = service.GetAll();
            return View(x);
        }
    }
}

