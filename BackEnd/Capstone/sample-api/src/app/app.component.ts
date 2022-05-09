import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { EmployeeService } from './employee.service';
import { IEmployee } from './models/employee';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  employees: IEmployee[] = [];
  employee: IEmployee | undefined;
  sub!: Subscription;
  constructor(private employeeService: EmployeeService){}

  ngOnInit(): void {
    this.sub = this.employeeService.getEmployees().subscribe({
      next: employees => this.employees = employees
    });
    this.sub = this.employeeService.getEmployee(1).subscribe({
      next: employee => this.employee = employee
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
