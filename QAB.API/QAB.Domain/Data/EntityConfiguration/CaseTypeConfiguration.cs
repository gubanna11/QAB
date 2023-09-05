using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Data.EntityConfiguration
{
    public class CaseTypeConfiguration : IEntityTypeConfiguration<CaseType>
    {
        public void Configure(EntityTypeBuilder<CaseType> builder)
        {
            List<CaseType> types = new List<CaseType>()
            {
                new CaseType()
                {
                    Id = 1,
                    Name = "Post"
                },
                new CaseType()
                {
                    Id = 2,
                    Name = "Question"
                }
            };

            builder.HasData(types);
        }
    }
}
