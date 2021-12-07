using Shared;

public class Program {
    public static async Task Main(string[] argd){
        using var client = new AdventOfCodeClient();
        var input = (await client.GetAsync("2021/day/2/input")).ToList();
        Console.WriteLine($"Answer 1 {Assignment1(input)}");
        Console.WriteLine($"Answer 2 {Assignment2(input)}");
    }

    public static int Assignment1(List<string> input){
        var position = new Position();
        input.ForEach(position.ChangeCourseV1);
        return position.CalculatePosition;
    }

        public static int Assignment2(List<string> input){
        var position = new Position();
        input.ForEach(position.ChangeCourseV2);
        return position.CalculatePosition;
    }

}

public class Position{
    private int _horizontal = 0;
    private int _depth = 0;
    private int _aim = 0;

    public int CalculatePosition => _horizontal * _depth;

    public void ChangeCourseV1(string instruction) {

        switch(instruction){
            case string x when x.StartsWith("Up", StringComparison.OrdinalIgnoreCase):
            _depth -= int.Parse(instruction.Substring(3));
            break;
            case string x when x.StartsWith("Down", StringComparison.OrdinalIgnoreCase):
            _depth += int.Parse(instruction.Substring(5));
            break;
            case string x when x.StartsWith("Forward", StringComparison.OrdinalIgnoreCase):
            _horizontal += int.Parse(instruction.Substring(8));
            break;
            default:
            throw new ArgumentException(nameof(instruction));
        }
    }

        public void ChangeCourseV2(string instruction) {

        switch(instruction){
            case string x when x.StartsWith("Up", StringComparison.OrdinalIgnoreCase):
            _aim -= int.Parse(instruction.Substring(3));
            break;
            case string x when x.StartsWith("Down", StringComparison.OrdinalIgnoreCase):
            _aim += int.Parse(instruction.Substring(5));
            break;
            case string x when x.StartsWith("Forward", StringComparison.OrdinalIgnoreCase):
            var amount = int.Parse(instruction.Substring(8));
            _horizontal += amount;
            _depth += _aim * amount;
            break;
            default:
            throw new ArgumentException(nameof(instruction));
        }
    }

}