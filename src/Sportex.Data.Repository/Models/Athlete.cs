namespace Sportex.Data.Repository.Models
{
    using System;

    public class Athlete
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string IdentityCardNumber { get; set; }

        public string TaxNumber { get; set; }

        public byte[] Photo { get; set; }

        public Team? Team { get; set; }

        public int TeamId { get; set; }
    }
}