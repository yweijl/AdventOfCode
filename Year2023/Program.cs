// See https://aka.ms/new-console-template for more information

using Shared;

using var client = new AdventClient();
var result = await client.GetInputAsync();
Console.WriteLine(result);