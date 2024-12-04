using Runner;
using Shared;

var adventClient = new AdventClient(2024);
await DayFactory.GetAnswerAsync(2024, 1, Part.first, adventClient);
await DayFactory.GetAnswerAsync(2024, 1, Part.second, adventClient);
await DayFactory.GetAnswerAsync(2024, 2, Part.first, adventClient);
