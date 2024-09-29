using BookManagementService.Models;

namespace BookManagementService.Services;

public interface IBookService
{
    BookModel AddBook(BookModel book, out string errorMessage);
    bool EditBook(BookModel book, out string errorMessage);
    bool DeleteBook(int id);
}
