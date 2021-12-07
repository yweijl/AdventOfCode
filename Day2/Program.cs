using Shared;

public class Program
{
    public static async Task Main(string[] argd)
    {
        using var client = new AdventOfCodeClient();
        var input = (await client.GetAsync("2021/day/2/input")).ToList();
        Console.WriteLine($"Answer 1 {Assignment1(input)}");
        Console.WriteLine($"Answer 2 {Assignment2(input)}");
    }

    public static int Assignment1(List<string> input)
    {
        var position = new Position();
        input.ForEach(position.ChangeCourseV1);
        return position.CalculatePosition;
    }

    public static int Assignment2(List<string> input)
    {
        var position = new Position();
        input.ForEach(position.ChangeCourseV2);
        return position.CalculatePosition;
    }
}



internal class Position
{
    private int _horizontal = 0;
    private int _depth = 0;
    private int _aim = 0;

    private enum Direction
    {
        up, dowm, forward
    }

    private (Direction Direction, int value) GetInstruction(string instruction)
    {
        var instructions = instruction.Split(' ');
        var direction = Enum.Parse<Direction>(instructions.First());
        var value = int.Parse(instructions.Last());
        return (direction, value);
    }

    public int CalculatePosition => _horizontal * _depth;

    public void ChangeCourseV1(string instruction)
    {
        var (direction, value) = GetInstruction(instruction);
        switch (direction)
        {
            case Direction.up:
                _depth -= value;
                break;
            case Direction.dowm:
                _depth += value;
                break;
            case Direction.forward:
                _horizontal += value;
                break;
            default:
                throw new ArgumentException(nameof(instruction));
        }
    }

    public void ChangeCourseV2(string instruction)
    {
        var (direction, value) = GetInstruction(instruction);
        switch (direction)
        {
            case Direction.up:
                _aim -= value;
                break;
            case Direction.dowm:
                _aim += value;
                break;
            case Direction.forward:
                _horizontal += value;
                _depth += _aim * value;
                break;
            default:
                throw new ArgumentException(nameof(instruction));
        }
    }
}