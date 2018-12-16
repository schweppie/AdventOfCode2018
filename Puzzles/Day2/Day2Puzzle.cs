using System.Collections.Generic;

namespace AdventOfCode2018.Puzzles.Day2
{
    public abstract class Day2Puzzle : PuzzleBase
    {
        protected List<Box> boxes;
        
        public override void Initialize()
        {
            base.Initialize();
            
            boxes = new List<Box>();
            
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                Box box = new Box(line);
                box.InitializeDictionary();
                boxes.Add(box);
            }
        }

        protected override string GetPuzzleData()
        {
            return "/Day2Data.txt";
        }
    }
}
