using AdventOfCode2018.Core;

namespace AdventOfCode2018.Puzzles.Day3
{
    public class ElvePlan
    {
        public IntVector2 Origin;
        public IntVector2 Extends;

        public ElvePlan(IntVector2 origin, IntVector2 extends)
        {
            Origin = origin;
            Extends = extends;
        }
    }
}
