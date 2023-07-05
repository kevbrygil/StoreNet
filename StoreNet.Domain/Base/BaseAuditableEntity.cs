using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreNet.Domain.Entities
{
    public class BaseAuditableEntity<Tkey> : BaseEntity<Tkey>
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
