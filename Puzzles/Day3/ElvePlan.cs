using AdventOfCode2018.Core;

namespace AdventOfCode2018.Puzzles.Day3
{
    public class ElvePlan
    {
        public IntVector2 Origin;
        public IntVector2 Extends;

        public int Id;

        public bool SharingSpace;
        
        public ElvePlan(int id, IntVector2 origin, IntVector2 extends)
        {
            Origin = origin;
            Extends = extends;
            Id = id;

            SharingSpace = false;
        }
    }
}
