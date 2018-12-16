using System.Collections.Generic;

namespace AdventOfCode2018.Puzzles.Day2
{
    public class Day2Part1Puzzle : Day2Puzzle
    {
        public override string GetSolution()
        {
            List<Box> boxes = new List<Box>();

            int doubleCount = 0;
            int tripleCount = 0;
            int checksum = 0;
            
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                Box box = new Box(line);
                box.InitializeDictionary();
                boxes.Add(box);
            }

            for (int i = 0; i < boxes.Count; i++)
            {
                Box box = boxes[i];

                if (box.HasDoubleLetters())
                    doubleCount++;

                if (box.HasTripleLetters())
                    tripleCount++;
            }

            checksum = doubleCount * tripleCount;

            return checksum.ToString();
        }
    }
}
