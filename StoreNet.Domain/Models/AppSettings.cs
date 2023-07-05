using System.ComponentModel.DataAnnotations;

namespace StoreNet.Domain.Models
{
    public class AppSettings
    {
        public static string? ConnectionString { get; set; }
    }
}
