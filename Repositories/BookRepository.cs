using BookUI.Model;

public class BookRepository : IBookRepository {
    private readonly HttpClient httpClient;

    public BookRepository(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Bookstore>> GetAllBooks(){
        return await httpClient.GetFromJsonAsync<Bookstore[]>("/api/Bookstore");
    }

    public async Task<Bookstore> GetBookById(int id) {
        return await httpClient.GetFromJsonAsync<Bookstore>($"/api/Bookstore/{id}");
    }

    public async Task AddBook(Bookstore book) {
        await httpClient.PostAsJsonAsync("/api/Bookstore", book);
    }
}