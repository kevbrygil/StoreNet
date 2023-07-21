namespace StoreNet.Application.Users.Dtos
{
    public class UserAddDto
    {
        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsAdmin { get; set; }

        public int CustomerId { get; set; }
    }
}
