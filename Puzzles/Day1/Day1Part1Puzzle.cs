namespace AdventOfCode2018.Puzzles.Day1
{
    public class Day1Part1Puzzle : Day1Puzzle
    {
        public override string GetSolution()
        {
            int solution = 0;
            
            for (int i = 0; i < lines.Length; i++)
                solution += int.Parse(lines[i]);

            return solution.ToString();
        }
    }
}
