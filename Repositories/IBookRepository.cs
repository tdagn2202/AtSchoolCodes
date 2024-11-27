using BookUI.Model;

public interface IBookRepository {
    Task<IEnumerable<Bookstore>> GetAllBooks();
    Task<Bookstore> GetBookById(int id);
    Task AddBook(Bookstore book);
    Task DeleteBook(Bookstore book);
    Task<Bookstore> UpdateBook(Bookstore book);

}