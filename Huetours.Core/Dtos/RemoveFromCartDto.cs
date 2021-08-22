using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huetours.Core.Dtos
{
    public class RemoveFromCartDto
    {
        public Guid OrderLineId { get; set; }
    }
}
