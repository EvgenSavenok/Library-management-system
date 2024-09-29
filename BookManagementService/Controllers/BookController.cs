using BookManagementService.Services;
using InventoryManagementService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementService.Controllers;

public class BooksController(IBookService bookService) : Controller
{
    [HttpGet]
    public ActionResult AddBook()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult AddBook(BookModel model)
    {
        if (ModelState.IsValid)
        {
            var addedBook = bookService.AddBook(model, out string errorMessage);
            if (!addedBook.Equals(null))
                return RedirectToAction("DisplayListOfBooksPage");
            ModelState.AddModelError(string.Empty, errorMessage);
        }
        return View(model);
    }
    
    [HttpGet]
    public ActionResult EditBook(int id)
    {
        var book = GetBookById(id);
        if (book.Equals(null))
        {
            return NotFound();
        }
        return View(book);
    }
    
    [HttpPost]
    public ActionResult EditBook(BookModel model)
    {
        if (ModelState.IsValid)
        {
            bool isEdited = bookService.EditBook(model, out string errorMessage);
            if (isEdited)
                return RedirectToAction("DisplayListOfBooksPage");
            ModelState.AddModelError(string.Empty, errorMessage);
        }
        return View(model);
    }
    
    [HttpGet]
    public ActionResult DeleteBook(int id)
    {
        var book = GetBookById(id);
        if (book.Equals(null))
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        bookService.DeleteBook(id);
        return RedirectToAction("DisplayListOfBooksPage");
    }
    
    private List<BookModel> GetAllBooks()
    {
        return new List<BookModel>
        {
            // new BookModel { Id = 1, Name = "Книга 1", Author = "Автор 1", Year = 2020, Genre = "Жанр 1" },
            // new BookModel { Id = 2, Name = "Книга 2", Author = "Автор 2", Year = 2019, Genre = "Жанр 2" }
        };
    }

    private BookModel GetBookById(int id)
    {
        return GetAllBooks().FirstOrDefault(book => book.Id == id)!;
    }
    
    public IActionResult DisplayListOfBooksPage()
    {
        var books = GetAllBooks();
        return View(books);
    }
}
