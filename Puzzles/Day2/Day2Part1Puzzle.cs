namespace AdventOfCode2018.Puzzles.Day2
{
    public class Day2Part1Puzzle : Day2Puzzle
    {
        public override string GetSolution()
        {
            int doubleCount = 0;
            int tripleCount = 0;
            int checksum = 0;

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
