namespace AdventOfCode2018.Puzzles.Day3
{
    public class Day3Part1Puzzle : Day3Puzzle
    {
        public override string GetSolution()
        {
            int overlapArea = elveGrid.GetOverlapArea();
            
            return overlapArea.ToString();
        }
    }
}
