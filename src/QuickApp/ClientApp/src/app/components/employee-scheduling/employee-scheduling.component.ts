import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { merge } from 'rxjs/observable/merge';
import { of as observableOf } from 'rxjs/observable/of';
import { catchError } from 'rxjs/operators/catchError';
import { map } from 'rxjs/operators/map';
import { startWith } from 'rxjs/operators/startWith';
import { switchMap } from 'rxjs/operators/switchMap';
import { EmployeeSchedulingDataSource } from './employee-scheduling-data-source';
import { EmployeeSchedulingService } from '../../services/employee-scheduling-endpoint.service';
import { EmployeeScheduling } from '../../models/employee-scheduling';
import { DayOverview } from '../../models/day-overview';

@Component({
  selector: 'app-employee-scheduling',
  templateUrl: './employee-scheduling.component.html',
  styleUrls: ['./employee-scheduling.component.css']
})

export class EmployeeSchedulingComponent implements OnInit {

  @Input() scheduling: DayOverview[];

  displayedColumns = ['date', 'name', 'workingFrom'];
  dataSource: MatTableDataSource<DayOverview> | null;

  resultsLength = 0;
  isLoadingResults = true;

  constructor(private employeeSchedulingService: EmployeeSchedulingService) { }

  ngOnInit() {
    // this.employeeSchedulingService.getEmployeeSchedulingByMonth<DayOverview[]>().subscribe((result)=> {
    //   scheduling = result;
    // });
      this.dataSource = new MatTableDataSource<DayOverview>(this.scheduling);
    

  }

}


