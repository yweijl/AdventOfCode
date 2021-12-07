using Shared;

public class Program {
    public static async Task Main(string[] argd){
        using var client = new AdventOfCodeClient();
        var input = (await client.GetAsync("2021/day/2/input")).ToList();
        Console.WriteLine($"Answer 1 {Assignment1(input)}");
    }

    public static int Assignment1(List<string> input){
        var position = new Position();
        input.ForEach(position.ChangeCourse);
        return position.CalculatePosition;
    }

}

public class Position{
    private int _horizontal = 0;
    private int _vertical = 0;

    public int CalculatePosition => _horizontal * _vertical;

    public void ChangeCourse(string instruction) {

        switch(instruction){
            case string x when x.StartsWith("Up", StringComparison.OrdinalIgnoreCase):
            _vertical -= int.Parse(instruction.Substring(3));
            break;
            case string x when x.StartsWith("Down", StringComparison.OrdinalIgnoreCase):
            _vertical += int.Parse(instruction.Substring(5));
            break;
            case string x when x.StartsWith("Forward", StringComparison.OrdinalIgnoreCase):
            _horizontal += int.Parse(instruction.Substring(8));
            break;
            default:
            throw new ArgumentException(nameof(instruction));
        }
    }

}