using CalendarOfFred.Models;
using CalendarOfFred.Utils;

namespace CalendarOfFred.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents(DateTime? start, DateTime? end);
    }

    public class HardcodedEventRepository : IEventRepository
    {
        public IEnumerable<Event> GetEvents(DateTime? start, DateTime? end)
        {
            var todayDate = DateTime.Today;
            if (start == null)
            {
                start = new DateTime(todayDate.Year, 1, 1);
            }

            if (end == null)
            {
                end = new DateTime(todayDate.Year, 12, 31); 
            }

            IEnumerable<int> years = new int[] { start.Value.Year, end.Value.Year }.Distinct();
            List<Event> eventsList = new List <Event>();

            foreach (int year in years)
            {
                eventsList.Add(new Event("New Fr3d's Day", new DateOnly(year, 1, 1)));

                // Spooky Freds Day
                eventsList.Add(new Event("Spooky Fr3d's Day", new DateOnly(year, 10, 31)));

                // Fredsgiving
                eventsList.Add(new Event("Fr3dsgiving", new DateOnly(year, 11, 1).GetNthDayOfNthWeek(DayOfWeek.Thursday, 4)));

                // Xmas Dates
                eventsList.Add(new Event("Fr3dmas", new DateOnly(year, 2, 25)));
                DateOnly julyFredmas = new DateOnly(year, 7, 25);
                eventsList.Add(new Event("Fr3dmas in NotJuly", julyFredmas, julyFredmas.AddDays(7)));
                eventsList.Add(new Event("Fr3dmas", new DateOnly(year, 8, 25)));
                eventsList.Add(new Event("Fr3dmas", new DateOnly(year, 9, 25)));
                eventsList.Add(new Event("Fr3dmas", new DateOnly(year, 12, 25)));

                // Fred Birthdays
                eventsList.Add(new Event("Fredflin Stone's Birthday", new DateOnly(year, 2, 2)));
                eventsList.Add(new Event("Fred Rogers' Birthday", new DateOnly(year, 3, 20)));
                eventsList.Add(new Event("Fred Astaire's Birthday", new DateOnly(year, 5, 10)));
                eventsList.Add(new Event("Fred Allens' Birthday", new DateOnly(year, 5, 31)));
                eventsList.Add(new Event("Fred Hoyle's Birthday", new DateOnly(year, 6, 24)));
                eventsList.Add(new Event("Fred Dryer's Birthday", new DateOnly(year, 7, 6)));
                eventsList.Add(new Event("Fred Savage's Birthday", new DateOnly(year, 7, 9)));
                eventsList.Add(new Event("Fred Dalton Thompson's Birthday", new DateOnly(year, 8, 19)));
                eventsList.Add(new Event("Fred MacMurray's Birthday", new DateOnly(year, 8, 30)));
                eventsList.Add(new Event("Fred Mercury's Birthday", new DateOnly(year, 9, 5)));
                eventsList.Add(new Event("Fred Willards's Birthday", new DateOnly(year, 9, 8)));
                eventsList.Add(new Event("Fred Armisten's Birthday", new DateOnly(year, 12, 4)));

                // Important Fred Dates
                eventsList.Add(new Event("Fr3d's Birthday", new DateOnly(year, 8, 18)));
                eventsList.Add(new Event("International Fr3d's Day", new DateOnly(year, 9, 19)));
                eventsList.Add(new Event("National Fred Day", new DateOnly(year, 6, 29)));
            }

            return eventsList;
        }


    }
}
