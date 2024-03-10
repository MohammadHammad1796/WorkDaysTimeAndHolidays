using System;

namespace DateTImeTests;

internal class WorkTime
{
	public static DateTime AddWorkHoursAndDays(DateTime startDateTime, TimeSpan workStart, TimeSpan workEnd, DayOfWeek[] workDays, int days, double hours)
	{
		double workHours = (workEnd - workStart).TotalHours;
		days += (int)Math.Floor(hours / workHours);
		hours %= workHours;

		DateTime resultDateTime = startDateTime;
		bool isWorkDay() => Array.IndexOf(workDays, resultDateTime.DayOfWeek) >= 0;

		if (hours > 0)
		{
			// Calculate time to the end of the work day
			TimeSpan remainingWorkDay = workEnd - resultDateTime.TimeOfDay;

			// Check if there are remaining work hours in the current work day
			if (remainingWorkDay.TotalHours > 0)
			{
				// Adjust work hours to add based on remaining work hours or specified hours
				double workHoursToAdd = Math.Min(remainingWorkDay.TotalHours, hours);
				resultDateTime = resultDateTime.AddHours(workHoursToAdd);
				hours -= workHoursToAdd;
			}

			if (hours > 0)
			{
				resultDateTime = resultDateTime.AddDays(1);
				while (!isWorkDay())
				{
					resultDateTime = resultDateTime.AddDays(1);
				}
				resultDateTime = resultDateTime.Date + workStart;
				resultDateTime = resultDateTime.AddHours(hours);
			}
		}

		while (days > 0)
		{
			resultDateTime = resultDateTime.AddDays(1);
			if (isWorkDay())
				days--;
		}

		return resultDateTime;
	}
}
