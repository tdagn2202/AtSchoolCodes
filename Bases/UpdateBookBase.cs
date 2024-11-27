
using BookUI.Model;
using Microsoft.AspNetCore.Components;

namespace BookUI.Components.Pages;

public class UpdateBookBase : ComponentBase{
    [Inject]
    public IBookRepository methodCall { get; set; }

    [Parameter]
    public String id  { get; set; }

    [Inject]
    NavigationManager navigationManager { get; set; }

    public Bookstore book { get; set;}

    protected override async Task OnInitializedAsync()
    {
        book = await methodCall.GetBookById(int.Parse(id));
        Console.WriteLine(book.BookName);
    }

    public async Task UpdateBook()
    {
        await methodCall.UpdateBook(book);
        navigationManager.NavigateTo("/booklist");
    }
}