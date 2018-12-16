using System;
using AdventOfCode2018.Puzzles.Day1;
using AdventOfCode2018.Puzzles.Day2;

namespace AdventOfCode2018
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var puzzle = new Day1Part1Puzzle();
            
            puzzle.Initialize();
            Console.WriteLine("Solution is: " + puzzle.GetSolution());
            Console.ReadKey();
        }
    }
}
