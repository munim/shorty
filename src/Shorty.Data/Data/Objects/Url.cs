using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shorty.Data.Data.Objects;
using Shorty.Data.DataObjects;

namespace Shorty.Core.Data.Objects
{
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string ShortUrl { get; set; }

        public string FullUrl { get; set; }

        public AppUser OwnedBy { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public virtual ICollection<VisitLog> VisitLogs { get; set; }
    }
}