namespace Fubon_T.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime AddTime { get; set; }

    }
}
