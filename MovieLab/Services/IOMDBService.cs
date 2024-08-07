using MovieLab.Models;

namespace MovieLab.Services;

public interface IOMDBService
{
    Task<OMDBResponse> SearchMovies(string movieName, string omdbKey);
}
