using System.Collections.Generic;

namespace AdventOfCode2018.Puzzles.Day1
{
    public class Day1Part2Puzzle : Day1Puzzle
    {
        public override string GetSolution()
        {
            int currentFrequency = 0;
            List<int> numbers = new List<int>();
            List<int> frequencies = new List<int>();
            
            for (int i = 0; i < lines.Length; i++)
                numbers.Add(int.Parse(lines[i]));

            frequencies.Add(currentFrequency);

            bool foundSolution = false;
            while (!foundSolution)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    int result = currentFrequency + number;

                    currentFrequency = result;

                    if (frequencies.Contains(currentFrequency))
                    {
                        foundSolution = true;
                        break;
                    }
                    else
                        frequencies.Add(currentFrequency);
                }
            }

            return currentFrequency.ToString();
        }
    }
}