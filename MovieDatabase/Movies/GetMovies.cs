using KrisInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Movies
{
    public class GetMovies
    {
        public static async Task GetJsonDataAll()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://moviesdatabase.p.rapidapi.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "7306dc1932msh2d45ff9ccce401ap193e40jsn0c2d7d3d328b");

            HttpResponseMessage response = await client.GetAsync("/titles");
            if (response.IsSuccessStatusCode)
            {
                // Gör om responsen till en sträng
                var responseBody = await response.Content.ReadAsStringAsync();
                // Console.WriteLine(responseBody);
                try
                {
                    // Gör om strängen till vår egen skapade datatyp - MoviesResponse
                    // Denna gång består svaret av endast ett objekt! Inte en lista!
                    // KrisInfo returnerade en lista!
                    // Däremot innehåller objektet en lista som heter "Results"
                    // Det är den listan vi vill komm åt.
                    var movies = JsonConvert.DeserializeObject<MoviesResponse>(responseBody);

                    if (movies != null)
                    {
                        Console.WriteLine("Samtliga Filmer");
                        Console.WriteLine($"Entries: {movies.entries}");
                        Console.WriteLine("******************");

                        // I movies json objektet finns det en lista som heter "Results"
                        foreach (var message in movies.Results)
                        {
                            Console.WriteLine($"Id: {message.id}");
                            Console.WriteLine($"Filmtitel: {message.TitleText.text}");
                            Console.WriteLine($"År: {message.ReleaseYear.year}");
                            Console.WriteLine("========================================");
                        }
                    }

                    Console.WriteLine("Tryck valfri knapp för att fortsätta");
                    Console.ReadLine();
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Prutt! Det funkade inte.");
                }
            }
        }

        public static async Task GetJsonDataOne(string id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://moviesdatabase.p.rapidapi.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "7306dc1932msh2d45ff9ccce401ap193e40jsn0c2d7d3d328b");

            HttpResponseMessage response = await client.GetAsync($"/titles/{id}");
            if (response.IsSuccessStatusCode)
            {
                // Gör om responsen till en sträng
                var responseBody = await response.Content.ReadAsStringAsync();
                // Console.WriteLine(responseBody);
                try
                {
                    // Gör om strängen till vår egen skapade datatyp - MovieSingleResponse
                    // Denna gång består svaret av endast ett objekt! Inte en lista!
                    // KrisInfo returnerade en lista!
                    // Objektet innehåller ett til objekt som heter "Results"
                    // Det är det objektet vi vill komm åt.
                    var movie = JsonConvert.DeserializeObject<MovieSingleResponse>(responseBody);

                    if (movie != null)
                    {
                        Console.WriteLine("En vald Film");
                        Console.WriteLine("******************");

                        // I single movie json objektet finns det ett objekt som heter "Results"
                        Console.WriteLine($"Id: {movie.Results.id}");
                        Console.WriteLine($"Filmtitel: {movie.Results.TitleText.text}");
                        Console.WriteLine($"År: {movie.Results.ReleaseYear.year}");
                        Console.WriteLine("========================================");
                    }

                    Console.WriteLine("Tryck valfri knapp för att fortsätta");
                    Console.ReadLine();
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Prutt! Det funkade inte.");
                }
            }
        }
    }
}
