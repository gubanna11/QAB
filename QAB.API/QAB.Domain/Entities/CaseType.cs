using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Entities
{
    public class CaseType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
    }
}
