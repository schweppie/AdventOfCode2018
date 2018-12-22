using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Puzzles.Day4
{
    public abstract class Day4Puzzle : PuzzleBase
    {
        protected List<Guard> guards = new List<Guard>();
        
        public static string Log;
        
        public const int START_MINUTE = 0;
        public const int END_MINUTE = 59;
        
        public override void Initialize()
        {
            base.Initialize();
            
            Regex guardExpression = new Regex(@"([#])(\d+)", RegexOptions.Compiled);
            Regex sleepExpression = new Regex(@"asleep", RegexOptions.Compiled);
            Regex wakeUpExpression = new Regex(@"wakes up", RegexOptions.Compiled);
            
            Guard currentGuard = null;

            string[] sortedLines = lines;
            Array.Sort(sortedLines, CompareLine);

            foreach (string line in sortedLines)
            {
                Log = line + " | ";
                
                //[1518-11-01 00:00] Guard #10 begins shift
                //[1518-11-01 00:05] falls asleep
                //[1518-11-01 00:25] wakes up

                // Begin shift 
                Match guardMatch = guardExpression.Match(line);
                if (guardMatch.Success)
                {
                    
                    int id = int.Parse(guardMatch.Groups[2].Value);
                    
                    var guard = guards.SingleOrDefault(g => g.Id == id);
                    if (guard == null)
                    {
                        currentGuard = new Guard(id);
                        guards.Add(currentGuard);
                    }
                    else
                        currentGuard = guard;
                }
                
                // Falls asleep
                Match sleepMatch = sleepExpression.Match(line);
                if(sleepMatch.Success)
                    currentGuard.Sleep( GetMinute(line));

                // Wakes up
                Match wakeUpMatch = wakeUpExpression.Match(line);
                if(wakeUpMatch.Success)
                    currentGuard.WakeUp(GetMinute(line));
                
                Console.WriteLine(Log);
            }
        }
        
        private Regex timeExpression = new Regex(@"(\d{2}):(\d{2})", RegexOptions.Compiled);
        private Regex dateTimeExpression = new Regex(@"\d+-\d+-\d+[ ]\d{2}:\d{2}");
        
        private int CompareLine(string a, string b)
        {
            DateTime aDateTime = GetDateTime(a);
            DateTime bDateTime = GetDateTime(b);

            return aDateTime.CompareTo(bDateTime);
        }

        private DateTime GetDateTime(string line)
        {
            Match dateTimeMatch = dateTimeExpression.Match(line);
            DateTime dateTime = DateTime.Parse(dateTimeMatch.Value);

            return dateTime;
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

        protected override string GetPuzzleData()
        {
            return "/Day4Data.txt";
        }        
    }
}
