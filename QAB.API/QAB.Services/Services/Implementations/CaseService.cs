using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QAB.Domain.Abstract.Interfaces;
using QAB.Domain.Data;
using QAB.Domain.Entities;
using QAB.Services.Models;
using QAB.Services.Models.Dtos.Case;
using QAB.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Services.Services.Implementations
{
    public class CaseService : ICaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CaseRequestDto> _caseRequestDtoValidator;

        public CaseService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CaseRequestDto> caseRequestDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _caseRequestDtoValidator = caseRequestDtoValidator;
        }

        public async Task<CaseDto> AddCaseAsync(CaseRequestDto caseRequestDto)
        {
            var result = _caseRequestDtoValidator.Validate(caseRequestDto);
            if (!result.IsValid)
            {
                string errors = string.Join('\n', result.Errors.Select(e => e.ErrorMessage));
                throw new Exception("Errors:\n" + errors);
            }

            Case caseEntity = _mapper.Map<Case>(caseRequestDto);

            caseEntity.PublishDate = DateTime.Now;
            caseEntity.PublishTime = DateTime.Now.TimeOfDay;
            caseEntity.AuthorId = " ";

            await _unitOfWork.GenericRpository<Case>().AddAsync(caseEntity);
            await _unitOfWork.SaveChangesAsync();

            CaseDto caseDto = _mapper.Map<CaseDto>(caseEntity);
            caseDto.Id = caseEntity.Id;
            return caseDto;
        }

        public async Task<IEnumerable<CaseDto>> GetAllCasesAsync()
        {
            var cases = await _unitOfWork
                               .GenericRpository<Case>()
                               .GetAllAsync(c => c.CaseType);

            var caseDtos = _mapper.Map<IEnumerable<CaseDto>>(cases);
            return caseDtos;
        }

        public async Task<CaseDto> GetCaseByIdAsync(int id)
        {
            Case caseEntity = await _unitOfWork
                                    .GenericRpository<Case>()
                                    .Table.Where(c => c.Id == id).Include(c => c.CaseType).FirstAsync();

            CaseDto caseDto = _mapper.Map<CaseDto>(caseEntity);
            return caseDto;
        }

        public async Task RemoveCaseAsync(int id)
        {
            _unitOfWork.GenericRpository<Case>().Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CaseDto> UpdateCase(CaseRequestDto caseRequestDto)
        {
            var result = _caseRequestDtoValidator.Validate(caseRequestDto);
            if (!result.IsValid)
            {
                string errors = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new Exception("Errors:\n" + errors);
            }

            Case caseEntity = _mapper.Map<Case>(caseRequestDto);

            _unitOfWork.GenericRpository<Case>().Update(caseEntity);
            await _unitOfWork.SaveChangesAsync();

            CaseDto caseDto = _mapper.Map<CaseDto>(caseEntity);

            return caseDto;
        }
    }
}
