using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreNet.Application.ProductsStores.Dtos
{
    public class ProductStoreUpdateDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
    }
}
