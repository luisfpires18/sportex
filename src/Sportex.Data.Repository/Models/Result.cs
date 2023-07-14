namespace Sportex.Data.Repository.Models
{
    using System;

    public class Result
    {
        public Guid Id { get; set; }

        public int ActivityId { get; set; }

        public Activity? Activity { get; set; }
    }
}