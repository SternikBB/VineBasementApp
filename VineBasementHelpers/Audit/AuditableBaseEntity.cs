using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Audit
{
    public class AuditableBaseEntity
    {
        [Column("Vb_CreatedBy")]
        public string CreatedBy { get; set; }

        [Column("Vb_Created")]
        public DateTime Created { get; set; }

        [Column("Vb_LastModifiedBy")]
        #nullable enable
        public string? LastModifiedBy { get; set; }
        #nullable disable

        [Column("Vb_LastModified ")]
        public DateTime? LastModified { get; set; }
    }
}
