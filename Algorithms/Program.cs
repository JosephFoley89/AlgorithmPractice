using Algorithms.Tests;

Console.Clear();

SortingTest sorting = new SortingTest(1000, 1000);
SearchingTest searching = new SearchingTest(10, 1000000);
GreedyTests greedy = new GreedyTests();
sorting.Execute(false);
searching.Execute();
greedy.ExecuteTests();