namespace OTASystem.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed passwords in a real app!
        public string Email { get; set; }
        public string Role { get; set; }  // Example: "Admin" or "User"
    }
}
