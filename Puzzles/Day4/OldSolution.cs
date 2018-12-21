/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Puzzles.Day4
{
    public class Day4Part1Puzzle : Day4Puzzle
    {
        private Regex timeExpression = new Regex(@"(\d{2}):(\d{2})", RegexOptions.Compiled);
        
        public override string GetSolution()
        {
            List<Guard> guards = new List<Guard>();

            Regex dateExpression = new Regex(@"(\d+)-(\d+)-(\d+)", RegexOptions.Compiled);
            Regex guardExpression = new Regex(@"([#])(\d+)", RegexOptions.Compiled);
            Regex sleepExpression = new Regex(@"asleep", RegexOptions.Compiled);
            Regex wakeUpExpression = new Regex(@"wakes up", RegexOptions.Compiled);

            Guard currentGuard = null;

            int startMinute = 0;
            int endMinute = 0;
            
            DateTime lastDateTime = DateTime.MinValue;

            bool isSleeping = false;
            
            foreach (string line in lines)
            {
                //[1518-11-01 00:00] Guard #10 begins shift
                //[1518-11-01 00:05] falls asleep
                //[1518-11-01 00:25] wakes up

                // Find date
                Match dateMatch = dateExpression.Match(line);
                int year = int.Parse(dateMatch.Groups[1].Value);
                int month = int.Parse(dateMatch.Groups[2].Value);
                int day = int.Parse(dateMatch.Groups[3].Value);
                DateTime dateTime = new DateTime(year, month, day);
               
                // Begin shift 
                Match guardMatch = guardExpression.Match(line);
                if (guardMatch.Success)
                {
                    if (isSleeping)
                    {
                        currentGuard.AddSleepPeriod(new SleepPeriod(startMinute, END_MINUTE)); 
                    }
                    
                    int id = int.Parse(guardMatch.Groups[2].Value);
                    
                    var guard = guards.SingleOrDefault(g => g.Id == id);
                    if (guard == null)
                    {
                        currentGuard = new Guard(id);
                        guards.Add(currentGuard);
                    }
                    else
                        currentGuard = guard;

                    isSleeping = false;
                    
                    lastDateTime = dateTime;
                }
                
                // Falls asleep
                Match sleepMatch = sleepExpression.Match(line);
                if (sleepMatch.Success)
                {
                    startMinute = GetMinute(line);
                    isSleeping = true;
                }

                // Wakes up
                Match wakeUpMatch = wakeUpExpression.Match(line);
                if (wakeUpMatch.Success)
                {
                    if (lastDateTime != dateTime)
                    {
                        startMinute = START_MINUTE;
                        lastDateTime = dateTime;
                    }

                    isSleeping = false;
                    
                    endMinute = GetMinute(line);
                    currentGuard.AddSleepPeriod(new SleepPeriod(startMinute, endMinute));
                }
            }
            
            guards.Sort();

            Guard bestGuard = guards[0];
            return (bestGuard.Id * bestGuard.GetMinuteSleptMost()).ToString();
        }


        private int GetMinute(string line)
        {
            Match minuteMatch = timeExpression.Match(line);
            int hour = int.Parse(minuteMatch.Groups[1].Value);
            int minute = int.Parse(minuteMatch.Groups[2].Value);
            if (hour != 0)
                minute = 0;

            return minute;
        }
    }
}
*/