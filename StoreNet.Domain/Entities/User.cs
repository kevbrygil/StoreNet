using System.ComponentModel.DataAnnotations.Schema;

namespace StoreNet.Domain.Entities
{
    public partial class User: BaseEntity<int>
    {
        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsAdmin { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        [NotMapped]
        public string? Token { get; set; }

    }
}
