import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatPaginator, MatSort, MatTableDataSource, DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material';

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
import { FormControl } from '@angular/forms';

import * as _moment from 'moment';
const moment =  _moment;

@Component({
  selector: 'app-employee-scheduling',
  templateUrl: './employee-scheduling.component.html',
  styleUrls: ['./employee-scheduling.component.css']
})

export class EmployeeSchedulingComponent implements OnInit {

  @Input() scheduling: EmployeeScheduling[];

  dateFrom = new FormControl(moment());
  dateTo = new FormControl(moment());

  displayedColumns = ['date', 'employee1', 'workingFrom1', 'employee2', 'workingFrom2', 'employee3', 'workingFrom3', 'employee4', 'workingFrom4'];
  dataSource: MatTableDataSource<EmployeeScheduling> | null;

  resultsLength = 0;
  isLoadingResults = true;

  constructor(private employeeSchedulingService: EmployeeSchedulingService) { }

  ngOnInit() {
    // this.employeeSchedulingService.getEmployeeSchedulingByMonth<EmployeeScheduling[]>().subscribe((result)=> {
    //   this.scheduling = result;
    // });
    // if(this.scheduling)
    // {
    //   this.dataSource = new MatTableDataSource<EmployeeScheduling>(this.scheduling);
    // }
    // else {
      let dataSource = [];
      for(let i; i<29; i++){
        let scheduling = new EmployeeScheduling();
        scheduling.employee1.user.userName = "zamestnanec1";
        scheduling.employee2.user.userName = "zamestnanec2";
        scheduling.employee3.user.userName = "zamestnanec3";
        scheduling.employee4.user.userName = "zamestnanec4";
        scheduling.workingFrom1 = moment().toDate();
        scheduling.date = moment("3/"+i + "/2018").toDate();
        dataSource.push(scheduling);
      }
      this.dataSource = new MatTableDataSource<EmployeeScheduling>(dataSource);
      
    // }
    

  }

}


