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
    Console.WriteLine("Enter a film category. To see a list of options, please type !options.");
    Console.WriteLine("For a complete list of movies, type !everything ");
    string userInput = Console.ReadLine();
    if (ValidateUserInput(userInput))
    {
        CategorySearchReturn(userInput);
        if (ReplayCheck())
            break;
    }

}
bool ValidateUserInput(string userInput) //TODO Structure rest of program now that custom class is created.
{
    while (true)
    {
        try
        {
            if (userInput.ToLower().Contains("option") || userInput.ToLower().IndexOf("1") > 0) //case handling option list input TODO: Rework to be scalable?
            {
                Console.WriteLine(string.Join("\n", movieList.Select(x => x.Category).Distinct().ToList()));
                return false;
            }
            else if (userInput.ToLower().Contains("everything") || userInput.ToLower().IndexOf("2") > 0) 
            {
                Console.WriteLine(string.Format("{0, 25} {1, 15}", "Title","Category"));
                foreach (Movie movie in movieList)
                {
                    Console.WriteLine(string.Format("{0, 25} {1, 15}",movie.Title,movie.Category));
                }
                return false;
            }
            else if (movieList.Where(x => userInput.ToLower() == x.Category.ToLower()).Count() > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"No category named {userInput} was found. Please ensure the category you're looking for is a valid option.");
                return (false);
            }
                
        }
        catch
        {
            Console.WriteLine("Error resolving your input. This search feature only accepts specific film categories as valid parameters. Please try again.");
            return false;
        }
    }
}

void CategorySearchReturn(string userInput)
{
    foreach (Movie movie in movieList.Where(x => userInput.ToLower() == x.Category.ToLower()))
    {
        Console.WriteLine(string.Format("{0, 25} {1, 15}", movie.Title, movie.Category));
    }
}

static bool ReplayCheck() //checks to see if the user would like to input a new value, otherwise returns false
{
    Console.WriteLine("Would you like to search again?");
    string? userInput = Console.ReadLine();
    bool userInputValid = userInput.ToLower().Contains('y') || userInput.ToLower().Contains('n');

    while (!userInputValid)
    {
        Console.WriteLine("Error resolving input, please only answer 'y' or 'n'");
        userInput = Console.ReadLine();
        userInputValid = userInput.ToLower().Contains('y') || userInput.ToLower().Contains('n');
    }

    if (userInput.ToLower().Contains('y'))
        return true;
    else
    {
        Console.WriteLine("Goodbye.");
        return false;
    }
}

