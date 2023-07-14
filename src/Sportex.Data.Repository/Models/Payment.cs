namespace Sportex.Data.Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Payment
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public double Price { get; set; }

        //public Guid EnrollmentId { get; set; }

        //public Enrollment? Enrollment { get; set; }

        public int ExtraId { get; set; }

        public Extra? Extra { get; set; }
    }
}
