namespace Sportex.Data.Repository.Models
{
    public class Sport
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public List<Activity>? Activities { get; set; }
    }
}