using System.Collections.Generic;
using AdventOfCode2018.Core;

namespace AdventOfCode2018.Puzzles.Day3
{
    public class Day3Part1Puzzle : Day3Puzzle
    {
        public override string GetSolution()
        {
            List<ElvePlan> elvePlans = new List<ElvePlan>();
            
            Grid grid = new Grid(1000,1000);
            
            foreach (var line in lines)
            {
                var elements = line.Split(' ');
            
                //#1 @ 1,3: 4x4

                var originString = elements[2].Remove(elements[2].Length-1);
                var extendString = elements[3];

                var originData = originString.Split(',');
                var extendData = extendString.Split('x');
                
                IntVector2 origin = new IntVector2(int.Parse(originData[0]), int.Parse(originData[1]));
                IntVector2 extend = new IntVector2(int.Parse(extendData[0]), int.Parse(extendData[1]));
                
                elvePlans.Add(new ElvePlan(origin, extend));
            }

            foreach (var plan in elvePlans)
            {
                grid.AddElvePlan(plan);
            }

            return grid.GetOverlapCount().ToString();
        }
    }
}
