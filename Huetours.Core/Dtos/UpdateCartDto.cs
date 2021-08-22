using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huetours.Core.Dtos
{
    public class UpdateCartDto
    {
        public OrderLineQuantityDto[] OrderLines { get; set; }
    }
    public class OrderLineQuantityDto
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
    }
}
