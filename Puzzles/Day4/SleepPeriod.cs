namespace AdventOfCode2018.Puzzles.Day4
{
    public struct SleepPeriod
    {
        public readonly int StartMinute;
        public readonly int EndMinute;

        public SleepPeriod(int start, int end)
        {
            StartMinute = start;
            EndMinute = end;
        }

        public int Duration()
        {
            return EndMinute - StartMinute;
        }

        public bool IsInPeriod(int minute)
        {
            return minute >= StartMinute && minute < EndMinute;
        }
    }
}
