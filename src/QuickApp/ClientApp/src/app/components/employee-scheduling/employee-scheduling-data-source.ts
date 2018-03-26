import { EmployeeScheduling } from "../../models/employee-scheduling";
import { Observable } from "rxjs/Observable";
import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { DayOverview } from "../../models/day-overview";

export class EmployeeSchedulingDataSource extends DataSource<DayOverview> {
    constructor(private schedule: DayOverview[]) {
        super();
      }
      
    connect(collectionViewer: CollectionViewer): Observable<DayOverview[]> {
       return Observable.of(this.schedule);
    }

    disconnect(collectionViewer: CollectionViewer): void {
        throw new Error("Method not implemented.");
    }

  
    // connect(): Observable<EmployeeScheduling> {
    //   return Observable.of(this.schedule);
    // }
  }