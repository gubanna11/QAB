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
    public class CaseConfiguration : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            List<Case> cases = new List<Case>()
            {
                new Case() {
                    Id = 1,
                    AuthorId = "author",
                    Title = "Title Post",
                    Content = "Content...",
                    Description = "",
                    IsActive = true,
                    PublishDate = DateTime.Now,
                    PublishTime = DateTime.Now.TimeOfDay,
                    CaseTypeId = 1,
                },
                new Case() {
                    Id = 2,
                    AuthorId = "author",
                    Title = "Title Question",
                    Content = "Content...",
                    Description = "",
                    IsActive = true,
                    PublishDate = DateTime.Now,
                    PublishTime = DateTime.Now.TimeOfDay,
                    CaseTypeId = 2,
                },
                new Case() {
                    Id = 3,
                    AuthorId = "author",
                    Title = "Title Question",
                    Content = "Content...",
                    Description = "",
                    IsActive = true,
                    PublishDate = DateTime.Now,
                    PublishTime = DateTime.Now.TimeOfDay,
                    CaseTypeId = 2,
                },
                new Case() {
                    Id = 4,
                    AuthorId = "author",
                    Title = "Title Question",
                    Content = "Content...",
                    Description = "",
                    IsActive = false,
                    PublishDate = DateTime.Now,
                    PublishTime = DateTime.Now.TimeOfDay,
                    CaseTypeId = 2,
                },
            };

            builder.HasData(cases);
        }
    }
}
