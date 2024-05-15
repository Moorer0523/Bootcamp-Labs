/*
What will the application do?
2 Points: Create 3 arrays and fill them with student information—one with name, one with hometown, one with favorite food
1 Point: Prompt the user to ask about a particular student by number. Convert the input to an integer. Use the integer as the index for the arrays. Print the student’s name.
1 Point: Ask the user which category to display: Hometown or Favorite food. Then display the relevant information.
1 Point: Ask the user if they would like to learn about another student.

Build Specifications:
1 Point: Validate user number: Use an if statement to check if the number is out of range, i.e. either less than 1 or greater than the length of the arrays. If so, display a friendly message and let the user try again.
1 Point: Validate category: Ask the user what information category to display: "Hometown" or "Favorite Food". Use an if statement to check that they entered either category name correctly. If they entered an incorrect category, display a friendly message and re-ask the question. (See hints below!)
1 Point: Array Length: Use the first array’s Length property in your code instead of hardcoding it.

Make sure the arrays are the same size.
Let the user enter a number from 1 up to and including the length of the array. To get the index, subtract 1 from the number they entered.
For the valid category: You might create a separate program to test out some code that uses a while loop and asks for either “Hometown” or “Favorite Food.” And only finishes the loop if either of these two is entered. Once you have it working, copy the code over to your “real” code.
Make it easy for the user – tell them what information is available
Try to use good grammar. Make your messages polite.

Extra Challenges:
1 Point: Provide an option where the user can see a list of all students.
2 Points: Allow the user to search by student name (Good challenge but difficult!)
1 Point: Category names: Allow uppercase and lowercase; allow portion of word such as "Food" instead of "Favorite Food"

 */



using System.Collections.Specialized;

//TODO Figure out standarized spacing for console reporting
//int index = 0;
//int alignmentSpacing = -25;
//string formatting = $"0, {alignmentSpacing}|";
//Console.WriteLine("Help is on the way. Now printing the entire table:");
//Console.WriteLine(string.Format(formatting, "This is a test space."));

Student student = new Student();

public class Student
{


    string[,] students = new string[,]
    {
        {"Alice", "Seattle", "Pizza" },
        {"Bob", "Chicago", "Sushi" },
        {"Charlie", "New York", "Burgers" },
        {"David", "Los Angeles", "Tacos" },
        {"Emma", "Miami", "Ice Cream" },
        {"Frank", "Dallas", "Pasta" },
        {"Grace", "San Francisco", "Salad" },
        {"Henry", "Boston", "Steak" },
        {"Isabella", "Denver", "Tacos" },
        {"Jack", "Houston", "Pancakes" },
    };

    ListDictionary nameDirectory = new ListDictionary
    {
        {0, "Alice" },
        {1, "Bob" },
        {2, "Charlie" },
        {3, "David" },
        {4, "Emma" },
        {5, "Frank" },
        {6, "Grace" },
        {7, "Henry" },
        {8, "Isabella" },
        {9, "Jack" }
    };

    private void HelpResponse()
    {
        Console.WriteLine("Help is on the way. Now printing the entire table:");
        Console.WriteLine(string.Format(" {0,-2} {1,-9} {2,-13} {3,-10}","ID", "Name", "Hometown", "Favorite Food" + Environment.NewLine));
        for (int i = 0; i < students.GetLength(0); i++)
        {
            Console.WriteLine(string.Format(" {0,-2} {1,-9} {2,-13} {3,-10}",i, students[i, 0], students[i, 1], students[i, 2]));
        }
    }
    string MainMenu()
    {
        Console.WriteLine("STUDENT DIRECTORY: Please enter the student's name or their studentID. Type !Help to see a full list");
        string userInput = Console.ReadLine(); //options here are either null/void, incorrect, name, ID, help

        if (userInput.ToLower() == "!help") //handles help case
        {
            HelpResponse();
            return string.Empty;
        }
        else
        {
            while (string.IsNullOrEmpty(userInput)) //handles null/void
            {
                Console.WriteLine("Error, no input detected. Please try again. Enter the student name or their studentID. Type !Help to see a full list");
                userInput = Console.ReadLine();
            }
            if (int.TryParse(userInput, out int id)) //handles ID input
            { return id.ToString(); }
            else
            {
                for (int i = 0; i < students.GetLength(0); i++)
                {
                    if (userInput.ToLower() == students[i, 0].ToLower())
                        return students[i, 0];
                }
                return string.Empty;
            }

        }
    }

    private void HelpDisplay()
    {
        Console.WriteLine("Request for help approved, now printing all available student information");
        for (int i = 0; i < students.GetLength(0);)
        {

        }
    }
    public static void main()
    {

    }
}