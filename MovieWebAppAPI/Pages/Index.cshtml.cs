using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDatabase.Movies;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MovieWebAppAPI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<MoviesResponse> Movies { get; set; }

        public async Task GetJsonDataAll()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://moviesdatabase.p.rapidapi.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "2a85b7850dmshd169ee09dede708p1584fcjsn15788fd3d197");

            HttpResponseMessage response = await client.GetAsync("/titles");
            if (response.IsSuccessStatusCode)
            {
                // Gör om responsen till en sträng
                // Console.WriteLine(responseBody);

                // Gör om strängen till vår egen skapade datatyp - MoviesResponse
                // Denna gång består svaret av endast ett objekt! Inte en lista!
                // KrisInfo returnerade en lista!
                // Däremot innehåller objektet en lista som heter "Results"
                // Det är den listan vi vill komm åt.

                var responseBody = await response.Content.ReadAsStringAsync();
                var movie = JsonConvert.DeserializeObject<MoviesResponse>(responseBody);
                Movies = new List<MoviesResponse> { movie };
            }
        }

        public async Task OnGet()
        {
            await GetJsonDataAll();
        }
    }
}