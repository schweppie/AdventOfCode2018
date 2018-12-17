using System;

namespace AdventOfCode2018.Puzzles.Day3
{
    public class Grid
    {
        private int[,] data;
        private int width;
        private int height;
        
        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            
            data = new int[width,height];
        }

        public void AddElvePlan(ElvePlan plan)
        {
            int startX = Math.Max(plan.Origin.X, 0);
            int startY = Math.Max(plan.Origin.Y, 0);

            int extendX = Math.Min(startX + plan.Extends.X, width);
            int extendY = Math.Min(startY + plan.Extends.Y, height);
            
            for (int x = startX; x < extendX; x++)
            {
                for (int y = startY; y < extendY; y++)
                {
                    data[x, y] += 1;
                }
            }
        }

        public void DebugDraw()
        {
            for (int y = 0; y < height; y++)
            {
                string debugLine = string.Empty;
                
                for (int x = 0; x < width; x++)
                {
                    debugLine += data[x, y].ToString();
                }
                
                Console.WriteLine(debugLine);
            }
        }

        public int GetOverlapCount()
        {
            int overlapCount = 0;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (data[x, y] > 1)
                        overlapCount += 1;
                }
            }

            return overlapCount;
        }
    }
}
