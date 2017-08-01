import { Component, OnInit } from '@angular/core';
import { WorkingRecord } from "../core/models/working-records";
import { Http } from "@angular/http";

@Component({
    selector: 'appc-working-records',
    templateUrl: './working-records.component.html',
    styleUrls: ['./working-records.component.scss']
})
export class WorkingRecordsComponent implements OnInit {

    workingRecords: WorkingRecord[];
    test: string[];
    constructor(private http: Http) {
    }

    ngOnInit() {
        this.workingRecords = [];
    }

    show() {
        this.http.get("./api/WorkingRecords/").subscribe(res => { this.workingRecords = res.json(); });
    
    }
    
    clockIn() {
        this.http.post("./api/WorkingRecords/ClockIn/", JSON.stringify("")).subscribe(re => this.workingRecords = re.json());
    }
    clockOut() {
        this.http.post("./api/WorkingRecords/ClockOut/", JSON.stringify("")).subscribe(re => this.workingRecords = re.json());
    }
}
