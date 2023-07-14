namespace Sportex.Data.Repository.Models
{
    public class Trophy
    {
        public int Id { get; set; }

        public int Description { get; set; }

        public int ActivityId { get; set; }

        public Activity? Activity { get; set; }
    }
}