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
// import {default as _rollupMoment} from 'moment';
const moment =  _moment;

@Component({
  selector: 'app-employee-scheduling',
  templateUrl: './employee-scheduling.component.html',
  styleUrls: ['./employee-scheduling.component.css'],
  providers: [
    // `MomentDateAdapter` and `MAT_MOMENT_DATE_FORMATS` can be automatically provided by importing
    // `MatMomentDateModule` in your applications root module. We provide it at the component level
    // here, due to limitations of our example generation script.
    // {provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]},
    // {provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},
  ],
})

export class EmployeeSchedulingComponent implements OnInit {

  @Input() scheduling: DayOverview[];

  dateFrom = new FormControl(new Date());
  dateTo = new FormControl(new Date());

  displayedColumns = ['date', 'name', 'workingFrom'];
  dataSource: MatTableDataSource<DayOverview> | null;

  resultsLength = 0;
  isLoadingResults = true;

  constructor(private employeeSchedulingService: EmployeeSchedulingService) { }

  ngOnInit() {
    this.employeeSchedulingService.getEmployeeSchedulingByMonth<DayOverview[]>().subscribe((result)=> {
      this.scheduling = result;
    });
    if(this.scheduling)
    {
      this.dataSource = new MatTableDataSource<DayOverview>(this.scheduling);
    }
    else {
      
    }
    

  }

}


