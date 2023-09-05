using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public int CaseId { get; set; }
        public Case Case { get; set; }

        [StringLength(maximumLength: 10000)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public int ParentCommentId { get; set; }
    }
}
