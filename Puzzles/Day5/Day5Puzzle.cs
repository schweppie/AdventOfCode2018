using System;

namespace AdventOfCode2018.Puzzles.Day5
{
    public abstract class Day5Puzzle : PuzzleBase
    {
        protected string ParsePolymer(string data)
        {
            char activeChar;
            char checkChar;
            
            int i = 0;
            while(i < data.Length-2)
            {
                activeChar = data[i];
                checkChar = data[i + 1];

                if ((Char.IsUpper(activeChar) && Char.IsLower(checkChar) ||
                     Char.IsLower(activeChar) && Char.IsUpper(checkChar)) &&
                    Char.ToLower(activeChar) == Char.ToLower(checkChar))
                {
                    data = data.Remove(i, 2);
                    i = 0;
                }
                else
                    i++;
            }
           
            return data;
        }
        
        protected override string GetPuzzleData()
        {
            return "/Day5Data.txt";
        }
    }
}
