using Shared;

namespace Year2023.Days;

public class Day2 : Day
{
    protected override int InputDay => 2;

    public Day2(bool executeFirst, bool executeSecond, AdventClient client) : base(executeFirst, executeSecond, client)
    {
    }

    protected override async Task<string> ExecuteFirstAsync()
    {
        var matches = await GetStrategyGuideAsync();
        var result = matches.Sum(match => match.GetMatchPoints);
        return result.ToString();
    }


    protected override async Task<string> ExecuteSecondAsync()
    {
        var matches = (await GetStrategyGuideAsync()).ToList();
        matches.ForEach(x => x.UpdateMyGesture());
        var result = matches.Sum(match => match.GetMatchPoints);
        return result.ToString();
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
        private Gesture _myGesture;
        private readonly Gesture _opponentGesture;
        private readonly OutCome _outCome;
        
        public int GetMatchPoints => CalculateMatchPoint();

        private int GetMyGestureValue => _myGesture switch
        {
            Gesture.Rock => 1,
            Gesture.Paper => 2,
            Gesture.Scissor => 3,
            _ => throw new ArgumentException("Invalid input"),
        };

        public Match(char firstValue, char secondValue)
        {
            _myGesture = DecryptGesture(secondValue);
            _opponentGesture = DecryptGesture(firstValue);
            _outCome = GetOutCome(secondValue);
        }
        
        public void UpdateMyGesture()
        {
            _myGesture = (_outCome, _opponentGesture) switch
            {
                (OutCome.Loose, Gesture.Rock )=> Gesture.Scissor,
                (OutCome.Loose, Gesture.Paper )=> Gesture.Rock,
                (OutCome.Loose, Gesture.Scissor )=> Gesture.Paper,
                (OutCome.Win, Gesture.Rock) => Gesture.Paper,
                (OutCome.Win, Gesture.Paper) => Gesture.Scissor,
                (OutCome.Win, Gesture.Scissor) => Gesture.Rock,
                _ => _opponentGesture,
            };
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

        private static OutCome GetOutCome(char outcome) => outcome switch
        {
            'X' => OutCome.Loose,
            'Y' => OutCome.Draw,
            'Z' => OutCome.Win,
            _ => throw new ArgumentException("Invalid input"),
        };

        private static Gesture DecryptGesture(char gesture) => gesture switch
        {
            'X' or 'A' => Gesture.Rock,
            'Y' or 'B' => Gesture.Paper,
            'Z' or 'C' => Gesture.Scissor,
            _ => throw new ArgumentException("Invalid input"),
        };
        
        private enum Gesture
        {
            Rock,
            Paper,
            Scissor
        }

        private enum OutCome
        {
            Loose,
            Draw,
            Win,
        }
    }
}