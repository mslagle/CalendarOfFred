using CalendarOfFred.Models;
using CalendarOfFred.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

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
                eventsList.Add(new Event("New Fr3d's Day", new DateOnly(year, 1, 1)) { Url = "/Home/Holidays#newfr3dsday" });

                // Spooky Freds Day
                eventsList.Add(new Event("Spooky Fr3d's Day", new DateOnly(year, 10, 31)) { Url = "/Home/Holidays#spookyday" });

                // Fredsgiving
                eventsList.Add(new Event("Fr3dsgiving", new DateOnly(year, 11, 1).GetNthDayOfNthWeek(DayOfWeek.Thursday, 4)) { Url = "/Home/Holidays#fr3dsgiving" });

                // Xmas Dates
                eventsList.Add(new Event("Fr3dmas", new DateOnly(year, 2, 25)) { Url = "/Home/Holidays#fr3dmas"});
                DateOnly julyFredmas = new DateOnly(year, 7, 1).GetNthDayOfNthWeek(DayOfWeek.Sunday, 2);
                eventsList.Add(new Event("12 Days of Fredmas", julyFredmas, julyFredmas.AddDays(12)) { Url = "/Home/Holidays#fr3dmas" });
                eventsList.Add(new Event("Fr3dmas", new DateOnly(year, 8, 25)) { Url = "/Home/Holidays#fr3dmas" });
                eventsList.Add(new Event("Fr3dmas", new DateOnly(year, 9, 25)) { Url = "/Home/Holidays#fr3dmas" });
                eventsList.Add(new Event("Fr3dmas", new DateOnly(year, 12, 25)) { Url = "/Home/Holidays#fr3dmas" });

                // Fred Birthdays
                eventsList.Add(new Event("Fred Flinstone's Birthday", new DateOnly(year, 2, 2)) { Url = "https://en.wikipedia.org/wiki/Fred_Flintstone" });
                eventsList.Add(new Event("Fred Rogers' Birthday", new DateOnly(year, 3, 20)) { Url = "https://en.wikipedia.org/wiki/Fred_Rogers" });
                eventsList.Add(new Event("Fred Astaire's Birthday", new DateOnly(year, 5, 10)) { Url = "https://en.wikipedia.org/wiki/Fred_Astaire" });
                eventsList.Add(new Event("Fred Allens' Birthday", new DateOnly(year, 5, 31)) { Url = "https://en.wikipedia.org/wiki/Fred_Allen" });
                eventsList.Add(new Event("Fred Hoyle's Birthday", new DateOnly(year, 6, 24)) { Url = "https://en.wikipedia.org/wiki/Fred_Hoyle" });
                eventsList.Add(new Event("Fred Dryer's Birthday", new DateOnly(year, 7, 6)) { Url = "https://en.wikipedia.org/wiki/Fred_Dryer" });
                eventsList.Add(new Event("Fred Savage's Birthday", new DateOnly(year, 7, 9)) { Url = "https://en.wikipedia.org/wiki/Fred_Savage" });
                eventsList.Add(new Event("Fred Dalton Thompson's Birthday", new DateOnly(year, 8, 19)) { Url = "https://en.wikipedia.org/wiki/Fred_Thompson" });
                eventsList.Add(new Event("Fred Durst's Birthday", new DateOnly(year, 8, 20)) { Url = "https://en.wikipedia.org/wiki/Fred_Durst" });
                eventsList.Add(new Event("Fred MacMurray's Birthday", new DateOnly(year, 8, 30)) { Url = "https://en.wikipedia.org/wiki/Fred_MacMurray" });
                eventsList.Add(new Event("Freddie Mercury's Birthday", new DateOnly(year, 9, 5)) { Url = "https://en.wikipedia.org/wiki/Freddie_Mercury" });
                eventsList.Add(new Event("Fred Willards's Birthday", new DateOnly(year, 9, 8)) { Url = "https://en.wikipedia.org/wiki/Fred_Willard" });
                eventsList.Add(new Event("Fred Armisen's Birthday", new DateOnly(year, 12, 4)) { Url = "https://en.wikipedia.org/wiki/Fred_Armisen" });

                // Important Fred Dates
                eventsList.Add(new Event("Fr3d's Birthday", new DateOnly(year, 8, 18)) { Url = "/Home/Holidays#fr3dsbirthday" });
                eventsList.Add(new Event("International Fr3d's Day", new DateOnly(year, 9, 15)) { Url = "/Home/Holidays#fr3dsday" });
                eventsList.Add(new Event("National Fred Day", new DateOnly(year, 6, 29)) { Url = "https://nationaltoday.com/national-fred-day" });
            }

            return eventsList;
        }


    }
}
