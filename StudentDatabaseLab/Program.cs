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


using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

Student student = new Student();
student.main();
public class Student
{

    readonly string[,] students = new string[,]
    {
        {"Bob", "Chicago", "Sushi" },
        {"Charlie", "New York", "Burgers" },
        {"David", "Los Angeles", "Tacos" },
        {"Emma", "Miami", "Ice Cream" },
        {"Frank", "Dallas", "Pasta" },
        {"Grace", "San Francisco", "Salad" },
        {"Henry", "Boston", "Steak" },
        {"Isabella", "Denver", "Tacos" },
        {"Jack", "Houston", "Pancakes" },
        {"Alice", "Seattle", "Pizza" }
    };
    //Hashtable nameDirectory = new Hashtable //replaced with dictionary
    readonly Dictionary<int, string> nameDirectory = new Dictionary<int, string>
    {

        {1, "Bob" },
        {2, "Charlie" },
        {3, "David" },
        {4, "Emma" },
        {5, "Frank" },
        {6, "Grace" },
        {7, "Henry" },
        {8, "Isabella" },
        {9, "Jack" },
        {10, "Alice" }
    };
    readonly Dictionary<int, string> attributeMap = new Dictionary<int, string> //created away from hardcoding to account for further attributes later? IDK maybe should all be objects?
    {
        {0, "Name"},
        {1, "Hometown"},
        {2, "Favorite Food"},

    };

    private void HelpResponse()
    {
        Console.WriteLine("Help is on the way. Now printing the entire table:");
        Console.WriteLine(string.Format(" {0,-2} {1,-9} {2,-13} {3,-10}","ID", "Name", "Hometown", "Favorite Food" + Environment.NewLine));
        for (int i = 0; i < students.GetLength(0); i++)
        {
            Console.WriteLine(string.Format(" {0,-2} {1,-9} {2,-13} {3,-10}",i+1, students[i, 0], students[i, 1], students[i, 2]));
        }
        Console.WriteLine("Returning to main menu.");

    }

    //TODO Change from converting to string and searching array to converting string to into and using that to index?

    private string? StudentDetailSelection(string selectedAttribute, int arrayIndex) //refactored to combine all into a single method.
    {
        string userInput;
        while (true) //checks for null/void AND valid input
        {
            if (arrayIndex == 0)
            {
            Console.WriteLine($"Please enter the student's {selectedAttribute}. Type !Help to see a full list");
             userInput = Console.ReadLine(); //options here are either null/void, incorrect, name, ID, help
            }
            else
            {
                userInput = selectedAttribute;
            }

            if (userInput.ToLower() == "!help") //handles help case
            {
                HelpResponse();
            }
            else
            {
                if (int.TryParse(userInput, out int id) && arrayIndex == 0 && nameDirectory.ContainsKey(id)) //Checks for valid input of ID for name and converts to string name
                {
                    userInput = nameDirectory[id] as string;
                }
                for (int i = 0; i < students.GetLength(0); i++)
                {
                    if (userInput.ToLower() == students[i, 0].ToLower())
                        return students[i, arrayIndex];
                }
                Console.WriteLine("Error with reading your input. Returning to Main Menu");
            }
        }
    }
    private int StudentAttributePicker(string studentName)
    {
        while (true)
        {
            Console.WriteLine("Please input the desired information category. The current options are:");
            for (int i = 1; i < attributeMap.Count; i++)//starting at 1 to skip name printing
            {
                Console.WriteLine($"{i}. {attributeMap[i]}");
            }
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int id) && id < attributeMap.Count && id > 0)
            {
                return id;
            }
            else
            {
                for (int i = 1; i < attributeMap.Count;i++)
                {
                    if (attributeMap[i].ToLower().Contains(userInput.ToLower()))
                        return i;
                }
                Console.WriteLine("Error reading input. Please type either the information Category name or number.");
            }

        }
    }
    public void main()
    {
        while(true) { 
            Console.WriteLine($"Main Menu:");
            string studentName = StudentDetailSelection("name or ID",0);

            Console.WriteLine($"Looking up details for {studentName}.");

            int selectedAttribute = StudentAttributePicker(studentName);

            Console.WriteLine($"{studentName}'s {attributeMap[selectedAttribute]} is {StudentDetailSelection(studentName, selectedAttribute)}");

            //string homeTown = StudentDetailSelection(studentName, 1);
            //string favoriteFood = StudentDetailSelection(studentName,2);
            //Console.WriteLine($"{studentName} {homeTown} {favoriteFood}");

            Console.WriteLine("Would you like to look up details for another student?(Y/N)");
            if (Console.ReadLine().ToLower().Contains("n"))
                break;
        }
        Console.Write("Returning to the main menu. ");
    }
}