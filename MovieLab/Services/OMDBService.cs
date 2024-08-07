using MovieLab.Models;

namespace MovieLab.Services;

public class OMDBService : IOMDBService
{
    //make a method that calls the API and then returns the c# object from the json

    public async Task<OMDBResponse> SearchMovies(string movieName, string omdbKey)
    {
        //string key = "5f54fe63";
        string key = omdbKey;
        string baseUrl = $"http://www.omdbapi.com/?apikey={key}&s={movieName}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                OMDBResponse response = await client.GetFromJsonAsync<OMDBResponse>(baseUrl);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
