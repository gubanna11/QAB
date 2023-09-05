using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Entities
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public int TableId { get; set; }
        public TableForLikes Table { get; set; }

        public string EntityId { get; set; }
    }
}
