import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import CaseDto from 'src/app/models/case/caseDto';
import { CasesService } from 'src/app/services/cases.service';

@Component({
  selector: 'app-cases-list',
  templateUrl: './cases-list.component.html',
  styleUrls: ['./cases-list.component.css']
})
export class CasesListComponent implements OnInit{
  cases: CaseDto[] = [];

  constructor(private casesService: CasesService,
    private toastr: ToastrService,
    ){}

  ngOnInit(): void {
    this.casesService.getAll().subscribe({
      next: (cases:CaseDto[]) => {
        console.log(cases);
        
        this.cases = cases;      
      },
      error: (err) => {
        this.toastr.error(err.message);
      }
    })
  }
}
