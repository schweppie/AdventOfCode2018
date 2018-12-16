using System.IO;

namespace AdventOfCode2018.Puzzles
{
    public abstract class PuzzleBase
    {
        protected string[] lines;
        
        public void Initialize()
        {
            lines = File.ReadAllLines(GetPuzzlesDataPath());
        }

        protected string GetPuzzlesDataPath()
        {
            return Directory.GetCurrentDirectory() + "\\PuzzleData\\" + GetPuzzleData();
        }
        
        protected abstract string GetPuzzleData();
        
        public abstract string GetSolution();
    }
}
