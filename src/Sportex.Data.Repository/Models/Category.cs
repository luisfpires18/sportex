namespace Sportex.Data.Repository.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public string Gender { get; set; }

        public string Type { get; set; }

        public Activity? Activity { get; set; }

        public int ActivityId { get; set; }

        public Competition? Competition { get; set; }

        public int CompetitionId { get; set; }
    }
}