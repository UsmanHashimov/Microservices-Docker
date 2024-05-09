namespace Project.API.Models
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}
