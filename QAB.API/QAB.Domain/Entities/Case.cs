using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Entities
{
    public class Case
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        [StringLength(maximumLength: 50)]
        public string Title { get; set; }

        [StringLength(maximumLength: 500)]
        public string? Description { get; set; }

        [StringLength(120000, MinimumLength = 50)]
        public string Content { get; set; }

        public bool? IsActive { get; set; }
        
        public DateTime PublishDate { get; set; } = DateTime.Now;

        public int CaseTypeId { get; set; }
        public CaseType CaseType { get; set; }
    }
}
