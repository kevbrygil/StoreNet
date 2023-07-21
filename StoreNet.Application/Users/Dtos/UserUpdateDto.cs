using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreNet.Application.Users.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsAdmin { get; set; }

        public int CustomerId { get; set; }
    }
}
