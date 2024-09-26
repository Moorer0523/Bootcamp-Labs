package org.example;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    private static List<Movie> movies = new ArrayList<Movie>(){{
        add(new Movie("The Shawshank Redemption", "Drama"));
        add(new Movie("Inception" , "Sci-Fi"));
        add(new Movie("The Godfather" , "Drama"));
        add(new Movie("Your Name." , "Animated"));
        add(new Movie("Forrest Gump" , "Drama"));
        add(new Movie("Weathering with You", "Animated"));
        add(new Movie("The Matrix", "Sci-Fi"));
        add(new Movie("Schindler's List", "Drama"));
        add(new Movie("Jurassic Park", "Sci-Fi"));
        add(new Movie("Titanic", "Drama"));
    }};


    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String movieCategory;
        while(true){


            while (true) {
                System.out.println("Enter movie category: ");
                try {
                    movieCategory = input.nextLine();
                    break;
                } catch(Exception e){
                    System.out.println("Error resolving your input, please try again");
                }
            }

            String finalMovieCategory = movieCategory;
            List<Movie> filterdList = movies.stream()
                    .filter(x -> x.getCategory().toLowerCase().contains(finalMovieCategory.toLowerCase())).toList();

            if(filterdList.size() == 0){
                System.out.println("No matches found");
            }
            else
            {
                filterdList.forEach(x -> System.out.printf("Title: %25s | Category: %-10s\n",x.getTitle(), x.getCategory()));
            }

            System.out.println("Would you like to search again? (y/n)");
            String answer = input.nextLine();
            while (!answer.equalsIgnoreCase("y") && !answer.equalsIgnoreCase("n")) {
                System.out.println("Could not read your answer. Would you like to search again? (y/n)");
                answer = input.nextLine();
            }

            if (answer.equalsIgnoreCase("n")) {
                System.out.println("Goodbye!");
                break;
            }

        }
        }
    }