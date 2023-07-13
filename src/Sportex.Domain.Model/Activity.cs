namespace Sportex.Domain.Model
{
    public class Activity
    {
        public int ActivityID { get; set; }

        public string? Name { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        public int SportID { get; set; }

        public Sport? Sport { get; set; }
    }
}