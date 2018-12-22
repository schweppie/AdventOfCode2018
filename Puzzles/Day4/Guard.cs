using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Puzzles.Day4
{
    public class Guard
    {
        private List<SleepPeriod> sleepPeriods;

        public readonly int Id;

        private int lastSleepMinute;
       
        public Guard(int id)
        {
            Id = id;
            sleepPeriods = new List<SleepPeriod>();
        }

        public void WakeUp(int minute)
        {
            SleepPeriod period = new SleepPeriod(lastSleepMinute, minute);
            AddSleepPeriod(period);

            Day4Puzzle.Log += " Guard " + Id + " was sleeping, adding sleep period: " + period.Duration() + " minutes";
        }
        
        public void Sleep(int minute)
        {
            Day4Puzzle.Log += " Guard " + Id + " sleeps now";
            lastSleepMinute = minute;
        }

        private void AddSleepPeriod(SleepPeriod period)
        {
            sleepPeriods.Add(period);
        }

        public int GetSleepDuration()
        {
            int sleepDuration = 0;
            
            foreach (SleepPeriod sleepPeriod in sleepPeriods)
            {
                sleepDuration += sleepPeriod.Duration();
            }

            return sleepDuration;
        }

        public KeyValuePair<int, int> GetMinuteSleptMost()
        {
            Dictionary<int, int> sleepingMinutes = new Dictionary<int, int>();
            
            for (int i = Day4Puzzle.START_MINUTE; i < Day4Puzzle.END_MINUTE; i++)
            {
                foreach (SleepPeriod sleepPeriod in sleepPeriods)
                {
                    if (!sleepPeriod.IsInPeriod(i))
                        continue;

                    if(!sleepingMinutes.ContainsKey(i))
                        sleepingMinutes.Add(i, 1);
                    else
                        sleepingMinutes[i] += 1;
                }
            }

            var sortedMinutes = sleepingMinutes.OrderByDescending(m => m.Value).ToList();

            if (sortedMinutes.Count > 0)
                return sortedMinutes[0];

            return new KeyValuePair<int, int>(0,0);
        }
    }
}
