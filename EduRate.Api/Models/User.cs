namespace EduRate.Api.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        // Additional fields like Name, Role, etc. can be added as needed.
    }
}