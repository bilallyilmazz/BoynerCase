using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AuditableEntity: BaseEntity, IAuditableEntity
    {
        protected AuditableEntity()
        {
            AddedDate = DateTime.Now;  
            ModifiedDate = DateTime.Now;
            IsActive = true;
        }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
