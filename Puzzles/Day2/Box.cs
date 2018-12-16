using System.Collections.Generic;

namespace AdventOfCode2018.Puzzles.Day2
{
    public class Box
    {
        private string id;
        private Dictionary<char, int> dictionary = new Dictionary<char,int>();

        public Box(string id)
        {
            this.id = id;
        }

        public void InitializeDictionary()
        {
            for (int i = 0; i < id.Length; i++)
            {
                char letter = id[i];

                if (dictionary.ContainsKey(letter))
                    dictionary[letter] += 1;
                else
                    dictionary.Add(letter, 1);
            }
        }

        public bool HasDoubleLetters()
        {
            foreach (var pair in dictionary)
            {
                if (pair.Value == 2)
                    return true;
            }

            return false;
        }

        public bool HasTripleLetters()
        {
            foreach (var pair in dictionary)
            {
                if (pair.Value == 3)
                    return true;
            }

            return false;
        }
    }
}
