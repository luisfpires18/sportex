namespace Sportex.Data.Repository.Models
{
    using System;

    public class Enrollment
    {
        public Guid EnrollmentID { get; set; }

        public string Notes { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; }

        public int ActivityId { get; set; }

        public Activity? Activity { get; set; }

        public int AthleteId { get; set; }

        public Athlete? Athlete { get; set; }

        public int PaymentId { get; set; }

        public Payment? Payment { get; set; }
    }
}