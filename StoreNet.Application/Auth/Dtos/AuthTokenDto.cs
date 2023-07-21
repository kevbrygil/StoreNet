namespace StoreNet.Application.Auth.Dtos
{
    public class AuthTokenDto
    {
        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public bool IsAdmin { get; set; }

        public int CustomerId { get; set; }

        public string Token { get; set; } = null!;

    }
}
