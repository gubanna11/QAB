import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import CaseDto from '../models/case/caseDto';

@Injectable({
  providedIn: 'root'
})
export class CasesService {
  private url = 'Cases';

  constructor(private http: HttpClient) { }

  public getAll():Observable<CaseDto[]>{
    return this.http.get<CaseDto[]>(`${environment.apiUrl}/${this.url}`);
  }
  
  public deleteCase(id: number):Observable<any>{
    return this.http.delete<any>(`${environment.apiUrl}/${this.url}/${id}`);
  }
}
