import { Injectable, Injector } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { ConfigurationService } from './configuration.service';
import { EndpointFactory } from './endpoint-factory.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EmployeeSchedulingService extends EndpointFactory {
    private readonly _employeeSchedulingMonthUrl: string = "/api/EmployeeScheduling/month";

    get employeeSchedulingUrl() { return this.configurations.baseUrl + this._employeeSchedulingMonthUrl; }

    constructor(http: HttpClient, configurations: ConfigurationService, injector :Injector) {
        super(http, configurations, injector);
     }

     getEmployeeSchedulingByMonth<EmployeeScheduling>(month?: number) : Observable<EmployeeScheduling>{
        let endpointUrl = `${this.employeeSchedulingUrl}/${month}`;

        return this.http.get<EmployeeScheduling>(endpointUrl, this.getRequestHeaders())
            .catch(error => {
                return this.handleError(error, () => this.getEmployeeSchedulingByMonth(month));
            });
     }

     setEmployeeSchedulingByMonth<T>(scheduledInterval: any) : Observable<T>{
        let endpointUrl = `${this.employeeSchedulingUrl}`;

        return this.http.post<T>(endpointUrl, JSON.stringify(scheduledInterval), this.getRequestHeaders())
            .catch(error => {
                return this.handleError(error, () => this.setEmployeeSchedulingByMonth(scheduledInterval));
            });
     }
    
}