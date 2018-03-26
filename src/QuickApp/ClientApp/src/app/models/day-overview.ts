import { Employee } from "./employee";

export class DayOverview {
    date: Date;
    amountHandedOver: number;
    amountReceipt: number;
    evaluation: string;
    
    employees: Employee[];
    events: Event[];

    missingStocks: string;
    runngingLowStuff: string;
    brokenStuff: string;
}