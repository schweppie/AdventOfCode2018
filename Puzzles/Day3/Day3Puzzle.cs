using System.Collections.Generic;
using AdventOfCode2018.Core;

namespace AdventOfCode2018.Puzzles.Day3
{
    public abstract class Day3Puzzle : PuzzleBase
    {
        private const int GRID_SIZE = 1000;
        
        protected List<ElvePlan> elvePlans;
        protected ElveGrid elveGrid;
        
        public override void Initialize()
        {
            base.Initialize();
            
            elvePlans = new List<ElvePlan>();
            elveGrid = new ElveGrid(GRID_SIZE, GRID_SIZE);
            
            foreach (var line in lines)
            {
                var elements = line.Split(' ');
            
                //#1 @ 1,3: 4x4

                var originString = elements[2].Remove(elements[2].Length-1);
                var extendString = elements[3];

                var originData = originString.Split(',');
                var extendData = extendString.Split('x');

                int elveId = int.Parse(elements[0].Remove(0, 1));
                
                IntVector2 origin = new IntVector2(int.Parse(originData[0]), int.Parse(originData[1]));
                IntVector2 extend = new IntVector2(int.Parse(extendData[0]), int.Parse(extendData[1]));
                
                elvePlans.Add(new ElvePlan(elveId, origin, extend));
            }

            foreach (var plan in elvePlans)
            {
                elveGrid.AddElvePlan(plan);
            }            
        }

        protected override string GetPuzzleData()
        {
            return "/Day3Data.txt";
        }
    }
}
