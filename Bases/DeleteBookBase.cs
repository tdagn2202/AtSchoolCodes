using System.Runtime.InteropServices;
using BookUI.Model;
using Microsoft.AspNetCore.Components;


namespace BookUI.Components.Pages;
public class DeleteBookBase : ComponentBase {
    [Inject]
    public IBookRepository apiCalling { get; set; }

    [Parameter]
    public string id { get; set; }

    [Inject]
    public NavigationManager navigationManager { get; set; }

    public Bookstore book { get; set; } = new Bookstore();

    protected async override Task OnInitializedAsync(){
        book = await apiCalling.GetBookById(int.Parse(id));
    }

    public async Task handleDelete(){
        await apiCalling.DeleteBook(book);
        navigationManager.NavigateTo("/booklist");
    }
}