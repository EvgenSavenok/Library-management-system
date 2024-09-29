using BookManagementService.Models;

namespace BookManagementService.Services;

public class BookService : IBookService
{
    public BookModel AddBook(BookModel book, out string errorMessage)
    {
        var dbAction = new Action();
        var result = dbAction.AddBook(book);
        if (!result.IsSuccess)
        {
            errorMessage = result.ErrorMessage;
            return null!;
        }
        errorMessage = string.Empty;
        return book;
    }

    public bool EditBook(BookModel book, out string errorMessage)
    {
        var dbAction = new Action();
        var result = dbAction.EditBook(book);
        if (!result.IsSuccess)
        {
            errorMessage = result.ErrorMessage;
            return false;
        }
        errorMessage = string.Empty;
        return true;
    }

    public bool DeleteBook(int id)
    {
        var dbAction = new Action();
        var result = dbAction.DeleteBook(id);
        if (!result.IsSuccess)
            return false;
        return true;
    }
}
