using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Foo
{
    /*
     * Complete the 'SearchSuggestions' function below.
     *
     * The function is expected to return a list of string lists (2D_STRING_ARRAY).
     * The function accepts following parameters:
     * 	1. List (STRING_ARRAY) - reviewsRepository
     * 	2. String - userInput
     */

    public static List<List<string>> SearchSuggestions(List<string> reviewsRepository, string userInput)
    {
        userInput.ToLower();
        var filteredProducts = reviewsRepository.OrderBy(review => review).ToList();
        var reviewList = new List<List<string>>();
        for (int i = 0; i < userInput.Length; i++)
        {
            string search = userInput.Substring(0, i);
            filteredProducts = filteredProducts.Where(prod => prod.StartsWith(search)).ToList();
            reviewList.Add(filteredProducts.Take(3).ToList());
        }

        return reviewList;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        int reviewsRepositoryCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> reviewsRepository = new List<string>();

        for (int i = 0; i < reviewsRepositoryCount; i++)
        {
            string reviewsRepositoryItem = Console.ReadLine();
            reviewsRepository.Add(reviewsRepositoryItem);
        }

        string userInput = Console.ReadLine();

        List<List<string>> foo = Foo.SearchSuggestions(reviewsRepository, userInput);

        Console.WriteLine(String.Join("\n", foo.Select(x => String.Join(" ", x))));
    }
}