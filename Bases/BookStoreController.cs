using Microsoft.AspNetCore.Mvc;
using BookService.Model;

[Route("api/[controller]")]
[ApiController]

public class BookstoreController : ControllerBase {
    
    private readonly IBookStoreRepository bookMethods;

    public BookstoreController(IBookStoreRepository bookMethods)
    {
        this.bookMethods = bookMethods;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var books = await bookMethods.GetAllBooks();
            return Ok(books);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Bookstore>> GetEmployee(int id)
    {
        try
        {
            var result = await bookMethods.GetBookById(id);
            if (result == null)
                return NotFound();
            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error retrieving data from the database");
        }
    }

     [HttpPost]
    public async Task<ActionResult<Bookstore>> CreateEmployee(Bookstore book)
    {
        try
        {
            if (book == null)
            {
                return BadRequest();
            }

            var newAddingBook = await bookMethods.AddBook(book);

            return CreatedAtAction(nameof(GetEmployee), new { id = newAddingBook.BookNo }, newAddingBook);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error retrieving data from the database");
        }
    }
}
