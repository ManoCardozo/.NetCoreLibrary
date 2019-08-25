using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryServices
{
    public class DataHelpers
    {
        public static IEnumerable<string> HumanizeBuzHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach (var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.OpenTime);
                var closeTime = HumanizeTime(time.CloseTime);

                var timeEntry = $"{day} {openTime} to {closeTime}";

                hours.Add(timeEntry);
            }

            return hours;
        }

        private static string HumanizeDay(int number)
        {
            // our data correlates 1 -> Sunday, so subtract 1
            return Enum.GetName(typeof(DayOfWeek), number - 1);
        }

        private static string HumanizeTime(int time)
        {
            var result = TimeSpan.FromHours(time);
            return result.ToString("hh':'mm");
        }
    }
}
