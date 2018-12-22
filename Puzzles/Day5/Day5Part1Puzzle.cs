namespace AdventOfCode2018.Puzzles.Day5
{
    public class Day5Part1Puzzle : Day5Puzzle
    {
        public override string GetSolution()
        {
            return ParsePolymer(lines[0]).Length.ToString();
        }
    }
}
