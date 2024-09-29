namespace BookManagementService.Models;

public class BookModel
{
    public enum BookGenre
    {
        ScienceFiction,
        Adventures,
        Horror,
        LoveStories
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public int Year { get; set; }
    public BookGenre Genre { get; set; }
    public int Amount { get; set; }
}
