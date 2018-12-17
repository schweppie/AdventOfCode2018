using System.Linq;

namespace AdventOfCode2018.Puzzles.Day3
{
    public class Day3Part2Puzzle : Day3Puzzle
    {
        public override string GetSolution()
        {
            for (int x = 0; x < elveGrid.Width; x++)
            {
                for (int y = 0; y < elveGrid.Height; y++)
                {
                    if(elveGrid.Data[x,y] == null || elveGrid.Data[x,y].Count <= 1)
                        continue;

                    foreach (var elvePlan in elveGrid.Data[x,y])
                        elvePlan.SharingSpace = true;
                }
            }

            var uniquePlan = elvePlans.Single(x => x.SharingSpace == false);
            
            return uniquePlan.Id.ToString();
        }
    }
}