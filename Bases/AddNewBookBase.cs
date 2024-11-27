using BookUI.Model;
using Microsoft.AspNetCore.Components;

namespace BookUI.Components.Pages;

public class AddNewBookBase : ComponentBase {
    [Inject]
    public IBookRepository bookMethods { get; set; }
    
    [Inject]
    public NavigationManager navigationManager { get; set; }

    public Bookstore newBook { get; set; } = new Bookstore();

    public async Task AddNewBook(){
        await bookMethods.AddBook(newBook);
        navigationManager.NavigateTo("/booklist");
    }

}