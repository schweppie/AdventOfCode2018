using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Puzzles.Day5
{
    public class Day5Part2Puzzle : Day5Puzzle
    {
        public override string GetSolution()
        {
            List<string> unitTypes = new List<string>();

            foreach (char character in lines[0])
            {
                if(unitTypes.Contains(character.ToString().ToLower()))
                    continue;
                
                unitTypes.Add(character.ToString().ToLower());
            }

            string units = "";
            for (int i = 0; i < unitTypes.Count; i++)
                units += unitTypes[i] + ",";
            
            Console.WriteLine("Units to process: " + units);
            
            int length = int.MaxValue;
            foreach (string character in unitTypes)
            {
                Console.WriteLine("Handling " + character);
                
                string result = string.Copy(lines[0]);
                
                result = result.Replace(character, "");
                result = result.Replace(character.ToUpper(), "");
                result = ParsePolymer(result);
                
                if (result.Length < length)
                    length = result.Length;
            }
            
            return length.ToString();
        }
    }
}
