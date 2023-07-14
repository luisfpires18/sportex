namespace Sportex.Data.Repository.Models
{
    using System;

    public class Request
    {
        public int Id { get; set; }

        public string Type { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTimeOffset Date { get; set; } = DateTime.UtcNow;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}