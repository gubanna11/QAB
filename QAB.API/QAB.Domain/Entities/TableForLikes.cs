using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Entities
{
    public class TableForLikes
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 30)]
        public string ObjectType { get; set; }

        [StringLength(maximumLength: 100)]
        public string TableName { get; set; }
    }
}
