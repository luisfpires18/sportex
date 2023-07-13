namespace Sportex.Domain.Model.Inputs
{
    public class ActivityInput
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Score { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Score: {Score}";
        }
    }
}