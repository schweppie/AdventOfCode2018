﻿using System.Linq;

namespace AdventOfCode2018.Puzzles.Day4
{
    public class Day4Part1Puzzle : Day4Puzzle
    {
        public override string GetSolution()
        {
            guards = guards.OrderByDescending(g => g.GetSleepDuration()).ToList();
            
            Guard bestGuard = guards[0];
            return (bestGuard.Id * bestGuard.GetMinuteSleptMost().Key).ToString();
        }
    }
}
