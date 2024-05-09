namespace Position.API.Models
{
    public class PositionModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
    }
}
