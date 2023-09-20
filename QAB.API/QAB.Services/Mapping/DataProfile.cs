using AutoMapper;
using QAB.Domain.Entities;
using QAB.Services.Models.Dtos.Case;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Services.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            // Case
            CreateMap<CaseRequestDto, Case>();
            CreateMap<Case, CaseDto>();
        }
    }
}
