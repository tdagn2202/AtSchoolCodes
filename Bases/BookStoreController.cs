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


    [HttpPut("{id}")]
    public async Task<ActionResult<Bookstore>> UpdateEmployee(int id, Bookstore book)
    {
        try
        {
            if (id != book.BookNo)
                return BadRequest("Employee ID mismatch");

            var bookToUpdate = await bookMethods.GetBookById(id);

            if (bookToUpdate == null)
                return NotFound($"Employee with Id = {id} not found");

            return await bookMethods.UpdateBook(book);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error updating data");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Bookstore>> DeleteBook(int id)
    {
        try
        {
            var bookToDelete = await bookMethods.GetBookById(id);

            if (bookToDelete == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return await bookMethods.DeleteBook(id);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error deleting data");
        }
    }
}
