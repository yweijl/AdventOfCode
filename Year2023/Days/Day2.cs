using Shared;

namespace Year2023.Days;

public class Day2 : Day
{
    protected override int InputDay => 2;

    public Day2(AdventClient client) : base(client)
    {
    }

    protected override async Task<string> ExecuteFirstAsync()
    {
        var matches = await GetStrategyGuideAsync();
        var result = matches.Sum(match => match.GetMatchPoints);
        return result.ToString();
    }


    protected override Task<string> ExecuteSecondAsync()
    {
        throw new NotImplementedException();
    }

    private async Task<IEnumerable<Match>> GetStrategyGuideAsync()
    {
        var input = await GetInputAsync();
        return input.Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(matchString =>
                new Match(matchString[0], matchString[2]));
    }


    private class Match
    {
        private readonly Gesture _myGesture;
        private readonly Gesture _opponentGesture;
        public int GetMatchPoints => CalculateMatchPoint();

        private int GetMyGestureValue => _myGesture switch
        {
            Gesture.Rock => 1,
            Gesture.Paper => 2,
            Gesture.Scissor => 3,
            _ => throw new ArgumentException("Invalid input"),
        };

        public Match(char opponentEncryptedGesture, char myEncryptedGesture)
        {
            _myGesture = DecryptMeGesture(myEncryptedGesture);
            _opponentGesture = DecryptOpponentGesture(opponentEncryptedGesture);
        }

        private int CalculateMatchPoint()
        {
            
            if (_myGesture == _opponentGesture)
            {
                // Draw
                return 3 + GetMyGestureValue;
            }

            return (MyGesture: _myGesture, OpponentGesture: _opponentGesture) switch
            {
                // Win
                (Gesture.Paper, Gesture.Rock) or
                (Gesture.Scissor, Gesture.Paper) or
                (Gesture.Rock, Gesture.Scissor) => 6 + GetMyGestureValue,
                // Lose
                _ => GetMyGestureValue
            };
        }

        private static Gesture DecryptMeGesture(char me) => me switch
        {
            'X' => Gesture.Rock,
            'Y' => Gesture.Paper,
            'Z' => Gesture.Scissor,
            _ => throw new ArgumentException("Invalid input"),
        };

        private static Gesture DecryptOpponentGesture(char opponent) => opponent switch
        {
            'A' => Gesture.Rock,
            'B' => Gesture.Paper,
            'C' => Gesture.Scissor,
            _ => throw new ArgumentException("Invalid input"),
        };

        private enum Gesture
        {
            Rock,
            Paper,
            Scissor
        }
    }
}