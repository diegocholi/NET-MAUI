using System.Text.Json;
using System.Text.Json.Serialization;

namespace applicationMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadPostsAsync();
        }

        private async void LoadPostsAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            var posts = JsonSerializer.Deserialize<List<Post>>(response);
            postsListView.ItemsSource = posts;
        }
    }

    public class Post
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("body")]
        public string? Body { get; set; }
    }
}
