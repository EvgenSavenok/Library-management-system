using BookManagementService.Models;

namespace BookManagementService;

public class Action
{
    public (bool IsSuccess, string ErrorMessage) AddBook(BookModel book)
    {
        using BooksManagementContext db = new BooksManagementContext();
        var existingBook = db.Books.FirstOrDefault(u => u.Name == book.Name 
                                                        && u.Author == book.Author);
        if (existingBook != null)
            return (false, "Такая книга уже существует");
        Book newBook = new Book
        {
            Name = book.Name,
            Author = book.Author,
            Genre = book.Genre.ToString(),
            Amount = book.Amount,
            Year = book.Year,
        };
        db.Books.Add(newBook);
        db.SaveChanges();
        return (true, "нига успешно добавлена.");
    }

    public (bool IsSuccess, string ErrorMessage) DeleteBook(int id)
    {
        using BooksManagementContext db = new BooksManagementContext();
        var existingBook = db.Books.FirstOrDefault(u => u.Id == id);
        if (existingBook == null)
            return (false, "Такой книги не существует.");
        db.Books.Remove(existingBook);
        db.SaveChanges();
        return (true, "Книга успешно удалена.");
    }
    
    public (bool IsSuccess, string ErrorMessage) EditBook(BookModel book)
    {
        using BooksManagementContext db = new BooksManagementContext();
        var existingBook = db.Books.FirstOrDefault(u => u.Name == book.Name 
                                                        && u.Author == book.Author);
        if (existingBook == null)
            return (false, "Такой книги не существует.");
        existingBook.Name = book.Name;
        existingBook.Author = book.Author;
        existingBook.Genre = book.Genre.ToString();
        existingBook.Amount = book.Amount;
        existingBook.Year = book.Year;
        
        db.SaveChanges();
        return (true, "Данные книги успешно изменены.");
    }
}
