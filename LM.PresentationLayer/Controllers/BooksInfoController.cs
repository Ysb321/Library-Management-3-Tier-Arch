using LM.BussinessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static System.Reflection.Metadata.BlobBuilder;

namespace LM.PresentationLayer.Controllers
{
    public class BooksInfoController : Controller
    {
        IBooksRepo _booksRepo;
        public BooksInfoController(IBooksRepo booksRepo)
        {
            _booksRepo = booksRepo;
        }

        public IActionResult BooksInfo(int id)
        {
            var books = _booksRepo.List();
            if (id == 1)
            {
                books = books.Where(x => x.IsAvailable).ToList();
            }
            if (id == 2)
            {
                books = books.Where(x => !(x.IsAvailable)).ToList();
            }
            return View(books);

        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var book = _booksRepo.List().FirstOrDefault(x => x.BookId == id);
            return View(book);
        }
        public IActionResult Edit(int id)
        {
            var book = _booksRepo.List().FirstOrDefault(x => x.BookId == id);
            return book != null ? View(book) : NotFound();
        }

        public IActionResult Delete(int id)
        {
            var book = _booksRepo.List().FirstOrDefault(x => x.BookId == id);
            _booksRepo.Delete(id);
            TempData["DeletedMessage"] = "Record " + @book?.BookId + " deleted successfully 👍";
            return RedirectToAction("BooksInfo");
        }

        [HttpPost]

        public IActionResult Create(Books books)
        {
            if (!ModelState.IsValid)
            {
                var booksList = _booksRepo.List();
                return View("BooksInfo", booksList);
            }
            _booksRepo.Create(books);
            TempData["CreatedMessage"] = "Record is created successfully 👍";
            return Redirect("BooksInfo");
        }

        [HttpPost]
        public IActionResult Edit(Books books)
        {
            _booksRepo.Update(books);
            TempData["SuccessMessage"] = "Record " + @books.BookId + " updated successfully 👍";
            return RedirectToAction("BooksInfo");
        }

    }
}
