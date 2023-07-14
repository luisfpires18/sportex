namespace Sportex.Data.Repository.Models
{
    public class Competition
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Distance { get; set; }
    }
}