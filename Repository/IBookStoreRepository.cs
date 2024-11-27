using BookService.Model;

public interface IBookStoreRepository{
    Task<IEnumerable<Bookstore>> GetAllBooks();
    Task<Bookstore> GetBookById(int id);
    Task<Bookstore> AddBook(Bookstore book);
    Task<Bookstore> UpdateBook(Bookstore book);
    Task<Bookstore> DeleteBook(int id);
}