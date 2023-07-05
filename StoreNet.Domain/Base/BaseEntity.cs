using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreNet.Domain.Entities
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }

    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual required TKey Id { get; set; }
    }
}
