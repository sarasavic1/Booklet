using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class AuditLogDto
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public int UserId { get; set; }
        public string UseCaseName { get; set; }

    }
}
