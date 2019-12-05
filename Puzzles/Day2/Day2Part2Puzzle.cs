using System.Text;

namespace AdventOfCode2018.Puzzles.Day2
{
    public class Day2Part2Puzzle : Day2Puzzle
    {
        public override string GetSolution()
        {
            int index;
            
            foreach (var box in boxes)
            {
                foreach (var otherbox in boxes)
                {
                    if(box.Id == otherbox.Id)
                        continue;

                    if(!box.FindSingleDifference(otherbox, out index))
                        continue;
                    
                    string one = new string(box.Id).Remove(index, 1);
                    string another = new string(otherbox.Id).Remove(index, 1);

                    if (one == another)
                        return one;
                }
            }

            return NO_SOLUTION;
        }
    }
}
