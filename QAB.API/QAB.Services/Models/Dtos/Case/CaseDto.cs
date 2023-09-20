using QAB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Services.Models.Dtos.Case
{
    public class CaseDto
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; }

        public DateTime PublishDate { get; set; }

        public TimeSpan PublishTime { get; set; }

        public int CaseTypeId { get; set; }
        public CaseType CaseType { get; set; }
    }
}
