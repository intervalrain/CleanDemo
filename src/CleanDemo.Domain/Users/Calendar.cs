namespace CleanDemo.Domain.Users;

public class Calendar
{
    private readonly Dictionary<DateOnly, int> _calendar = new();

    public static Calendar Empty()
    {
        return new Calendar();
    }

    public void IncrementEventCount(DateOnly date)
    {
        if (!_calendar.ContainsKey(date))
        {
            _calendar[date] = 0;
        }
        ++_calendar[date];
    }

    public void DecrementEvenCount(DateOnly date)
    {
        if (!_calendar.ContainsKey(date))
        {
            return;
        }
        if (--_calendar[date] == 0)
        {
            _calendar.Remove(date);
        }
    }

    public void SetEventCount(DateOnly date, int numEvents)
    {
        if (numEvents <= 0)
        {
            throw new InvalidOperationException();
        }
        _calendar[date] = numEvents;
    }

    public int GetNumEventsOnDay(DateTimeOffset dateTime)
    {
        return _calendar.TryGetValue(DateOnly.FromDateTime(dateTime.Date), out var numEvents)
            ? numEvents
            : 0;
    }

    public Calendar()
    {
    }
}

