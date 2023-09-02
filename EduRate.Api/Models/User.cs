namespace EduRate.Api.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        // Additional fields like Name, Role, etc. can be added as needed.
    }
}