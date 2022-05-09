import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IEmployee } from './models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employeeUrl: string = 'https://localhost:44333/employees';
  constructor(private http: HttpClient) { }

  getEmployee(id:number): Observable<IEmployee> {
    return this.http.get<IEmployee>(this.employeeUrl + `/${id}`);
  }
  getEmployees(): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(this.employeeUrl);
  }
}
