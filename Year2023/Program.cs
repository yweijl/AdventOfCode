// See https://aka.ms/new-console-template for more information

using Shared;
using Year2023.Days;

using var client = new AdventClient();

var day2 = new Day2(client);
await day2.ExecuteAsync();