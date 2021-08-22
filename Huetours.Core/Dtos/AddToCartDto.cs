using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huetours.Core.Dtos
{
    public class AddToCartDto
    {
        public string ProductReference { get; set; }
        public decimal Quantity { get; set; }
    }
}
