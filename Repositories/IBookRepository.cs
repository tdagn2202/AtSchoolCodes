using BookUI.Model;

public interface IBookRepository {
    Task<IEnumerable<Bookstore>> GetAllBooks();
    Task<Bookstore> GetBookById(int id);
    Task AddBook(Bookstore book);
}