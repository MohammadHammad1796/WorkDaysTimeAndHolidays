using NUnit.Framework;
using System;

namespace DateTImeTests;

[TestFixture]
public class WorkTimeTests
{
	[Test]
	[TestCase(8, 30, 17, 0, 6, 9.5, 3, 11, 15, 24, 3, 20, 16, 24)]
	public void Test1(int workStartHour, int workStartMinute, int workEndHour,
		int workEndMinute, int days, double hours,
		int startDateTimeMonth, int startDateTimeDay, int startDateTimeHour, int startDateTimeMinute,
		int expectedDateTimeMonth, int expectedDateTimeDay, int expectedDateTimeHour, int expectedDateTimeMinute)
	{
		DayOfWeek[] workDays = {
			DayOfWeek.Sunday,
			DayOfWeek.Monday,
			DayOfWeek.Tuesday,
			DayOfWeek.Wednesday,
			DayOfWeek.Thursday
		};

		var workStart = new TimeSpan(workStartHour, workStartMinute, 0);
		var workEnd = new TimeSpan(workEndHour, workEndMinute, 0);
		var startDateTime = new DateTime(2024, startDateTimeMonth, startDateTimeDay, startDateTimeHour, startDateTimeMinute, 0);

		var result = WorkTime.AddWorkHoursAndDays(startDateTime, workStart, workEnd, workDays, days, hours);

		Assert.That(result.Month, Is.EqualTo(expectedDateTimeMonth));
		Assert.That(result.Day, Is.EqualTo(expectedDateTimeDay));
		Assert.That(result.Hour, Is.EqualTo(expectedDateTimeHour));
		Assert.That(result.Minute, Is.EqualTo(expectedDateTimeMinute));
	}
}