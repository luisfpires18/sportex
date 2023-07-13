namespace Sportex.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Sport
    {
        public int SportID { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public List<Activity>? Activities { get; set; }
    }
}
