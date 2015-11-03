using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shorty.Core.Data.Objects
{
    public class VisitLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        public string BrowserAgentString { get; set; }

        public DateTimeOffset VisitTime { get; set; }

        [StringLength(15)]
        public string IPv4 { get; set; }

        [StringLength(15)]
        public string IPv6 { get; set; }
    }
}