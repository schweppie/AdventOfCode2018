﻿using System;
using AdventOfCode2018.Puzzles.Day1;
using AdventOfCode2018.Puzzles.Day2;
using AdventOfCode2018.Puzzles.Day3;
using AdventOfCode2018.Puzzles.Day4;

namespace AdventOfCode2018
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var puzzle = new Day4Part1Puzzle();
            
            puzzle.Initialize();
            Console.WriteLine("Solution is: " + puzzle.GetSolution());
            Console.ReadKey();
        }
    }
}
