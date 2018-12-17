using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Puzzles.Day3
{
    public class ElveGrid
    {
        private List<ElvePlan>[,] data;
        public List<ElvePlan>[,] Data
        {
            get { return data; }
        }

        public readonly int Width;
        public readonly int Height;
        
        public ElveGrid(int width, int height)
        {
            Width = width;
            Height = height;
            
            data = new List<ElvePlan>[width , height];
        }

        public void AddElvePlan(ElvePlan plan)
        {
            int startX = Math.Max(plan.Origin.X, 0);
            int startY = Math.Max(plan.Origin.Y, 0);

            int extendX = Math.Min(startX + plan.Extends.X, Width);
            int extendY = Math.Min(startY + plan.Extends.Y, Height);
            
            for (int x = startX; x < extendX; x++)
            {
                for (int y = startY; y < extendY; y++)
                {
                    if(data[x, y] == null)
                        data[x, y] = new List<ElvePlan>();
                    
                    data[x, y].Add(plan);
                }
            }
        }

        public void DebugDraw()
        {
            for (int y = 0; y < Height; y++)
            {
                string debugLine = string.Empty;
                
                for (int x = 0; x < Width; x++)
                {
                    debugLine += data[x, y].ToString();
                }
                
                Console.WriteLine(debugLine);
            }
        }

        public int GetOverlapArea()
        {
            int overlapArea = 0;
            
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (data[x, y].Count > 1)
                        overlapArea += 1;
                }
            }

            return overlapArea;
        }
    }
}
