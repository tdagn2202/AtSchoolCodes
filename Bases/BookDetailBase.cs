using BookUI.Model;
using Microsoft.AspNetCore.Components;


namespace BookUI.Components.Pages;

public class BookDetailBase : ComponentBase {
    public Bookstore book { get; set;}
    [Inject]

    public IBookRepository bookRepository { get; set;}

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        book = await bookRepository.GetBookById(int.Parse(Id));
    }
}