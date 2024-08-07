namespace MovieLab.Models;

public class OMDBResponse
{
    public List<Movie> Search { get; set; }
    public string totalResults { get; set; }
    public string Response { get; set; }

}
