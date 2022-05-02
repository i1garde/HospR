using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Entities
{
    public record Doctor(
        int Id, 
        string Name, 
        string ContactNumber
        );
}
