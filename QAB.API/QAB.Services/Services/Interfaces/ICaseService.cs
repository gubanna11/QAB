using QAB.Domain.Entities;
using QAB.Services.Models.Dtos.Case;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Services.Services.Interfaces
{
    public interface ICaseService
    {
        Task<CaseDto> AddCaseAsync(CaseRequestDto caseModel);
        Task<CaseDto> GetCaseByIdAsync(int id);
        Task<IEnumerable<CaseDto>> GetAllCasesAsync();
        Task<CaseDto> UpdateCase(CaseRequestDto caseModel);
        Task RemoveCaseAsync(int id);
    }
}
