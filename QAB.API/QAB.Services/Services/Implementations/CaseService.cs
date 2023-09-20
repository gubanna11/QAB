﻿using AutoMapper;
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

        public CaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CaseDto> AddCaseAsync(CaseRequestDto caseRequestDto)
        {
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

        public async void RemoveCase(int id)
        {
            _unitOfWork.GenericRpository<Case>().Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CaseDto> UpdateCase(CaseRequestDto caseRequestDto)
        {
            Case caseEntity = _mapper.Map<Case>(caseRequestDto);

            _unitOfWork.GenericRpository<Case>().Update(caseEntity);
            await _unitOfWork.SaveChangesAsync();

            CaseDto caseDto = _mapper.Map<CaseDto>(caseEntity);
            
            return caseDto;
        }
    }
}
