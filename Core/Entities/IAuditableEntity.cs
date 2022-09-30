using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public interface IAuditableEntity
    {
         DateTime AddedDate { get; set; }
         DateTime ModifiedDate { get; set; }
         bool IsActive { get; set; }
    }
}
