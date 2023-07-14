namespace Sportex.Data.Repository.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class Management
    {
        public int Id { get; set; }

        public int? AthleteId { get; set; }

        public Athlete Athlete { get; set; }

        public Guid? UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}