using BookUI.Model;
using Microsoft.AspNetCore.Components;

namespace BookUI.Components.Pages;

public class BookListBase : ComponentBase{
    [Inject]
    public IBookRepository bookMethos { get; set; }
    public IEnumerable<Bookstore> bookList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        bookList = await bookMethos.GetAllBooks();
    }
}