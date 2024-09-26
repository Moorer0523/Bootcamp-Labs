package org.example;

import java.util.List;
import java.util.stream.Collectors;

public class Abomination {

    private List<Movie> movies;

    public Abomination(List<Movie> movieList) {
        this.movies = movieList;
    }

    public boolean getFilteredMovies(String filter) {
        if(!movies.stream()
                .filter(x -> x
                        .getCategory()
                        .toLowerCase()
                        .contains(filter.toLowerCase()))
                .collect(Collectors.toList())
                .isEmpty())
        {
            movies.stream()
                    .filter(x -> x
                            .getCategory()
                            .toLowerCase()
                            .contains(filter.toLowerCase()))
                    .forEach(x -> System.out.printf("Title: %25s | Category: %-10s\n",x.getTitle(), x.getCategory()));
            return !movies.stream()
                    .filter(x -> x
                            .getCategory()
                            .toLowerCase()
                            .contains(filter.toLowerCase()))
                    .collect(Collectors.toList())
                    .isEmpty();
        }
        else {
            return movies.stream()
                    .filter(x -> x
                            .getCategory()
                            .toLowerCase()
                            .contains(filter.toLowerCase()))
                    .collect(Collectors.toList())
                    .isEmpty();
        }
    }
}
