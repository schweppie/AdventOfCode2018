using System;

namespace AdventOfCode2018.Puzzles.Day5
{
    public class Day5Part1Puzzle : Day5Puzzle
    {
        public override string GetSolution()
        {
            return ParsePolymer(lines[0]).Length.ToString();
        }

        private string ParsePolymer(string data)
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

            Console.WriteLine("ParsedPolymer " + data);
            
            return data;
        }
    }
}