using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Models
{
    public class BaseClass
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
