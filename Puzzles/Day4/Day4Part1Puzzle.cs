using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Puzzles.Day4
{
    public class Day4Part1Puzzle : Day4Puzzle
    {
        private Regex timeExpression = new Regex(@"(\d{2}):(\d{2})", RegexOptions.Compiled);

        public static string LogMessage;
        
        Regex dateExpression = new Regex(@"(\d+)-(\d+)-(\d+)", RegexOptions.Compiled);
        
        private int CompareLine(string a, string b)
        {
            DateTime aDateTime = GetDateTime(a);
            DateTime bDateTime = GetDateTime(b);

            return aDateTime.CompareTo(bDateTime);
        }

        private DateTime GetDateTime(string line)
        {
            Match dateMatch = dateExpression.Match(line);
            int year = int.Parse(dateMatch.Groups[1].Value);
            int month = int.Parse(dateMatch.Groups[2].Value);
            int day = int.Parse(dateMatch.Groups[3].Value);
            
            Match minuteMatch = timeExpression.Match(line);
            int hour = int.Parse(minuteMatch.Groups[1].Value);
            int minute = int.Parse(minuteMatch.Groups[2].Value);
            
            DateTime dateTime = new DateTime(year, month, day);

            dateTime.AddHours(hour);
            dateTime.AddMinutes(minute);

            return dateTime;
        }
        
        public override string GetSolution()
        {
            List<Guard> guards = new List<Guard>();
            
            Regex guardExpression = new Regex(@"([#])(\d+)", RegexOptions.Compiled);
            Regex sleepExpression = new Regex(@"asleep", RegexOptions.Compiled);
            Regex wakeUpExpression = new Regex(@"wakes up", RegexOptions.Compiled);

            Guard currentGuard = null;

            string[] sortedLines = lines.ToArray();
            Array.Sort(sortedLines, CompareLine);

            DateTime lastDateTime = DateTime.MinValue;

            foreach (string line in sortedLines)
            {
                LogMessage = line + " | ";
                
                //[1518-11-01 00:00] Guard #10 begins shift
                //[1518-11-01 00:05] falls asleep
                //[1518-11-01 00:25] wakes up

                // Find date
                DateTime dateTime = GetDateTime(line);
                
                // Begin shift 
                Match guardMatch = guardExpression.Match(line);
                if (guardMatch.Success)
                {
                    if(currentGuard != null)
                        currentGuard.StopShift();
                    
                    int id = int.Parse(guardMatch.Groups[2].Value);
                    
                    var guard = guards.SingleOrDefault(g => g.Id == id);
                    if (guard == null)
                    {
                        currentGuard = new Guard(id);
                        guards.Add(currentGuard);
                    }
                    else
                        currentGuard = guard;
                    
                    currentGuard.StartShift();

                    lastDateTime = dateTime;
                }
                
                // Falls asleep
                Match sleepMatch = sleepExpression.Match(line);
                if(sleepMatch.Success)
                    currentGuard.Sleep(dateTime, GetMinute(line));

                // Wakes up
                Match wakeUpMatch = wakeUpExpression.Match(line);
                if(wakeUpMatch.Success)
                    currentGuard.WakeUp(dateTime, GetMinute(line));
                
                Console.WriteLine(LogMessage);
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
