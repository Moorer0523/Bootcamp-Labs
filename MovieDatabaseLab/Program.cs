using MovieDatabaseLab;
using System;


Main.Primary();
public static partial class Main
{
    static readonly List<Movie> movieList = new List<Movie>()
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

}

public static partial class Main {

    static Dictionary<int, string> categoryMenu = new Dictionary<int, string>();
    public static void Primary()
    {
        CategoryBuild(movieList);
        Console.WriteLine("Welcome to an example movie database.");
        while (true)
        {
            Console.WriteLine("Enter a film category. To see a list of options, please type !options.");
            Console.WriteLine("For a complete list of movies, type !everything ");
            string userInput = Console.ReadLine();
            if (ValidateUserInput(userInput))
            {
                CategorySearchReturn(userInput);
                if (!ReplayCheck())
                    break;
            }
        }
    }
    private static bool ValidateUserInput(string userInput) //TODO Structure rest of program now that custom class is created.
    {
        while (true)
        {
            try
            {
                if (userInput.ToLower().Contains("option") || userInput.IndexOf('1') > -1) //case handling option list input TODO: Rework to be scalable?
                {
                    Console.WriteLine(string.Join("\n", movieList.Select(x => x.Category).Distinct().ToList().Order()));
                    return false;
                }
                else if (userInput.ToLower().Contains("everything") || userInput.IndexOf('2') > -1)  //case handling everything input
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

    private static void CategorySearchReturn(string userInput)
    {
        //Ok too long. Dont use it like this.
        Console.WriteLine(string.Join("\n", movieList
            .Where(x => userInput.ToLower() == x.Category.ToLower()) //filter
            .OrderBy(x => x.Title)//sort
            .Select(x => string.Format("{0, 25} {1, 15}", x.Title, x.Category)) //format
            .ToList()));//push into list

        //foreach (Movie movie in movieList.Where(x => userInput.ToLower() == x.Category.ToLower()))
        //{
        //    Console.WriteLine(string.Format("{0, 25} {1, 15}", movie.Title, movie.Category));
        //}
    }

    private static bool ReplayCheck() //checks to see if the user would like to input a new value, otherwise returns false
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

    private static Dictionary<int, string> CategoryBuild(List<Movie> movies)
    {
        int i = 1;
        foreach (string categoryOption in movies.Select(x => x.Category).Distinct())
        {
            categoryMenu.Add(i, categoryOption);
            Console.WriteLine(categoryMenu[i]);
            i++;
        }
        return categoryMenu;
    }
}
