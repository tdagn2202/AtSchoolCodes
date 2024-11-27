using BookService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

public partial class BookStoreRepository : IBookStoreRepository
{
    BookstoreContext bookstoreContext { get; set; } = new BookstoreContext();

    int Id;
    public async Task<Bookstore> GetBookById(int id)
    {
        return (from books in bookstoreContext.Bookstores
                where books.BookNo == id
                select books).FirstOrDefault();
    }

    public async Task<IEnumerable<Bookstore>> GetAllBooks()
    {
        return bookstoreContext.Bookstores;
    }

    public async Task<Bookstore> AddBook(Bookstore book)
    {
        var result = await bookstoreContext.Bookstores.AddAsync(book);
        await bookstoreContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Bookstore> UpdateBook(Bookstore book)
    {
        var onEditingBook = await bookstoreContext.Bookstores
        .FirstOrDefaultAsync(props => props.BookNo == book.BookNo);

        if (onEditingBook != null)
        {
            onEditingBook.BookName = book.BookName;
            onEditingBook.Publisher = book.Publisher;
            onEditingBook.Quantity = book.Quantity;
            onEditingBook.UnitPrice = book.UnitPrice;

            await bookstoreContext.SaveChangesAsync();
            return onEditingBook;
        }

        return null;
    }

    public async Task<Bookstore> DeleteBook(int id)
    {
        var onDeletingBook = await bookstoreContext.Bookstores
        .FirstOrDefaultAsync(props => props.BookNo == id);

        if(onDeletingBook != null){
            bookstoreContext.Bookstores.Remove(onDeletingBook);
            await bookstoreContext.SaveChangesAsync();
            return onDeletingBook;
        }
        return null;
    }
}