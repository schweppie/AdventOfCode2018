using System.Collections.Generic;

namespace AdventOfCode2018.Puzzles.Day2
{
    public class Box
    {
        public string Id;
        private Dictionary<char, int> dictionary = new Dictionary<char,int>();

        public Box(string id)
        {
            Id = id;
        }

        public void InitializeDictionary()
        {
            for (int i = 0; i < Id.Length; i++)
            {
                char letter = Id[i];

                if (dictionary.ContainsKey(letter))
                    dictionary[letter] += 1;
                else
                    dictionary.Add(letter, 1);
            }
        }

        private bool HasNumberOfLetters(int amount)
        {
            foreach (var pair in dictionary)
            {
                if (pair.Value == amount)
                    return true;
            }

            return false;
        }
        
        public bool HasDoubleLetters()
        {
            return HasNumberOfLetters(2);
        }

        public bool HasTripleLetters()
        {
            return HasNumberOfLetters(3);
        }

        public bool FindSingleDifference(Box other, out int index)
        {
            int differences = 0;
            index = -1;
            
            for (int i = 0; i < Id.Length; i++)
            {
                if(other.Id.Contains(Id[i].ToString()))
                    continue;

                if (differences == 0)
                    index = i;
                
                differences += 1;
            }

            return (differences == 1);
        }
    }
}
