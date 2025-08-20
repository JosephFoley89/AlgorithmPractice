using Algorithms.Tests;

SortingTest sorting = new SortingTest(1000, 1000);
SearchingTest searching = new SearchingTest(10, 100000);
sorting.Execute(false);
searching.Execute();