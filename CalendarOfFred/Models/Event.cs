using System.Text.Json.Serialization;

namespace CalendarOfFred.Models
{
    public class Event
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("start")]
        public DateOnly Start { get; set; }

        [JsonPropertyName("end")]
        public DateOnly? End { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        public Event(string Title, DateOnly Start, DateOnly? End = null)
        {
            this.Title = Title;
            this.Start = Start;
            this.End = End;
        }
    }
}
