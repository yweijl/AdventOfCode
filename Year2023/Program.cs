// See https://aka.ms/new-console-template for more information

using Shared;
using Year2023.Days;

using var client = new AdventClient();

var day1 = new Day1(client);
var first  =await day1.ExecuteFirstAsync();
var second = await day1.ExecuteSecondAsync();

Console.WriteLine(first);
Console.WriteLine(second);