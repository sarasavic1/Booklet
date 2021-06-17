using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public string UseCaseName { get; set; }

        public virtual User User { get; set; }
    }
}
