using MovieDatabaseLab;

List<Movie> movieList = new List<Movie>() 
{ 
    new Movie("The Shawshank Redemption", "Drama"),
    new Movie("Inception" , "Sci-Fi"),
    new Movie("The Godfather" , "Drama"),
    new Movie("Your Name." , "Animated"),
    new Movie("Forrest Gump" , "Drama"),
    new Movie("Weathering with You", "Animated"),
    new Movie("The Matrix", "Sci-Fi"),
    new Movie("Schindler's List", "Drama"),
    new Movie("Jurassic Park", "Sci-Fi"),
    new Movie("Titanic", "Drama")
};

//foreach (Movie movie in Movies)
//    Console.WriteLine(movie.title + movie.category);

Console.WriteLine("Welcome to an example movie database.");
while (true)
{
    Console.WriteLine("Please enter a film category. To see a list of options, please type !options.");
    Console.WriteLine("For a complete list of movies, type !everything ");
    string userInput = Console.ReadLine();
    UserInputResolve(userInput);
}
string UserInputResolve(string userInput) //TODO Structure rest of program now that custom class is created.
{
    while (true)
    {
        try
        {
            if (userInput.ToLower().Contains("option") || userInput.ToLower().IndexOf("1") > 0) //case handling optionlist input TODO: Rework to be scalable?
            {
                Console.WriteLine(string.Join("\n", movieList.Select(x => x.Category).Distinct().ToList()));
            }
            else if (userInput.ToLower().Contains("everything") || userInput.ToLower().IndexOf("2") > 0) 
            {
                Console.WriteLine(string.Format("{0, 25} {1, 15}", "Title","Category"));
                foreach (Movie movie in movieList)
                {
                    Console.WriteLine(string.Format("{0, 25} {1, 15}",movie.Title,movie.Category));
                }
            }
            return "placeholder";
        }
        catch
        {
            Console.WriteLine("PANIC");
            return "placeholder";
        }
    }
}
//string OptionList()




