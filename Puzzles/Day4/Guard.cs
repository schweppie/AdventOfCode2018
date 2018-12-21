using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Puzzles.Day4
{
    public class Guard : IComparable
    {
        private List<SleepPeriod> sleepPeriods;

        public readonly int Id;
        private State state;

        private DateTime lastDateTime;
        private int lastSleepMinute;
        
        private enum State
        {
            Awake,
            Sleep,
        }
        
        public Guard(int id)
        {
            Id = id;
            sleepPeriods = new List<SleepPeriod>();
        }

        public void StartShift()
        {
            state = State.Awake;
            
            Day4Part1Puzzle.LogMessage += " Guard " + Id + " starts shift";
        }
        
        public void WakeUp(DateTime dateTime, int minute)
        {
            if (state == State.Awake)
            {
                SleepPeriod period = new SleepPeriod(Day4Puzzle.START_MINUTE, minute);
                AddSleepPeriod(period);
                
                Day4Part1Puzzle.LogMessage += " Guard " + Id + " was sleeping from the start, adding sleep period: " + period.Duration() + " minutes";
            }
            else
            {
                SleepPeriod period = new SleepPeriod(lastSleepMinute, minute);
                AddSleepPeriod(period);

                Day4Part1Puzzle.LogMessage += " Guard " + Id + " was sleeping, adding sleep period: " + period.Duration() + " minutes";
            }

            lastDateTime = dateTime;            
            state = State.Awake;
        }
        
        public void Sleep(DateTime dateTime, int minute)
        {
            if (dateTime != lastDateTime && state == State.Sleep)
            {
                SleepPeriod period = new SleepPeriod(lastSleepMinute, Day4Puzzle.END_MINUTE);
                
                Day4Part1Puzzle.LogMessage += " Guard " + Id + " only slept last date! adding " + period.Duration() + " minutes";
                AddSleepPeriod(period);
            }
            
            Day4Part1Puzzle.LogMessage += " Guard " + Id + " sleeps now";
            
            lastSleepMinute = minute;
            lastDateTime = dateTime;
            state = State.Sleep;
        }

        public void StopShift()
        {
            Day4Part1Puzzle.LogMessage += " Guard " + Id + " stops shift";

            if (state == State.Sleep)
            {
                SleepPeriod period = new SleepPeriod(lastSleepMinute, Day4Puzzle.END_MINUTE);
                AddSleepPeriod(period);

                Day4Part1Puzzle.LogMessage += " Guard " + Id + " was still asleep, adding sleep period: " + period.Duration() +
                                  " minutes";
            }
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

        public int GetMinuteSleptMost()
        {
            Dictionary<int, int> sleepingMinutes = new Dictionary<int, int>();
            
            for (int i = Day4Puzzle.START_MINUTE; i <= Day4Puzzle.END_MINUTE; i++)
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

            KeyValuePair<int, int> minuteSleptMost = new KeyValuePair<int, int>();
            
            foreach (var pair in sleepingMinutes)
            {
                if (pair.Value <= minuteSleptMost.Value)
                    continue;

                minuteSleptMost = pair;
            }

            return minuteSleptMost.Key;
        }

        public int CompareTo(object otherGuard)
        {
            Guard other = (Guard) otherGuard;
            if (other == null)
                return 0;

            if (GetSleepDuration() > other.GetSleepDuration())
                return -1;
            else
                return 1;
        }
    }
}
