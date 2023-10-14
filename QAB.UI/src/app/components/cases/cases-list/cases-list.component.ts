import { Component, OnInit } from '@angular/core';
import CaseDto from 'src/app/models/case/caseDto';
import { CasesService } from 'src/app/services/cases.service';

import * as toastr from 'toastr';

@Component({
  selector: 'app-cases-list',
  templateUrl: './cases-list.component.html',
  styleUrls: ['./cases-list.component.css']
})
export class CasesListComponent implements OnInit{
  cases: CaseDto[] = [];

  constructor(private casesService: CasesService,
    ){}

  ngOnInit(): void {
    this.getAllCases();
  }

  deleteCase(id: number){
    this.casesService.deleteCase(id).subscribe({
      next: (result) => {
        this.getAllCases();
        toastr.success(result.message);        
      },
      error: (err) => {
        toastr.error(err.detail);
      }
    })
  }

  getAllCases(){
    this.casesService.getAll().subscribe({
      next: (cases:CaseDto[]) => {        
        this.cases = cases;      
      },
      error: (err) => {
        toastr.error(err.message);
      }
    })
  }
}
