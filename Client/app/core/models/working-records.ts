import { ApplicationUser } from "./application-user";
import { WorkingRecordWorkingType } from "../../working-records.enum";

export class WorkingRecord implements IWorkingRecord {
    id?: number | undefined;
    userId: number;
    recordDate: Date;
    clockIn?: Date | undefined;
    clockOut?: Date | undefined;
    workingTime?: string | undefined;
    overTime?: string | undefined;
    workingType?: WorkingRecordWorkingType | undefined;
    user?: ApplicationUser | undefined;

    constructor(data?: IWorkingRecord) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.userId = data["userId"];
            this.recordDate = data["recordeDate"] ? new Date(data["recordeDate"].toString()) : <any>undefined;
            this.clockIn = data["clockIn"] ? new Date(data["clockIn"].toString()) : <any>undefined;
            this.clockOut = data["clockOut"] ? new Date(data["clockOut"].toString()) : <any>undefined;
            this.workingTime = data["workingTime"];
            this.overTime = data["overTime"];
            this.workingType = data["workingType"];
            this.user = data["user"] ? ApplicationUser.fromJS(data["user"]) : <any>undefined;
        }
    }

    static fromJS(data: any): WorkingRecord {
        let result = new WorkingRecord();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["userId"] = this.userId;
        data["recordDate"] = this.recordDate ? this.recordDate.toISOString() : <any>undefined;
        data["clockIn"] = this.clockIn ? this.clockIn.toISOString() : <any>undefined;
        data["clockOut"] = this.clockOut ? this.clockOut.toISOString() : <any>undefined;
        data["workingTime"] = this.workingTime;
        data["overTime"] = this.overTime;
        data["workingType"] = this.workingType;
        data["user"] = this.user ? this.user.toJSON() : <any>undefined;
        return data;
    }
}

export interface IWorkingRecord {
    id?: number | undefined;
    userId: number;
    recordeDate: Date;
    clockIn?: Date | undefined;
    clockOut?: Date | undefined;
    workingTime?: string | undefined;
    overTime?: string | undefined;
    workingType?: WorkingRecordWorkingType | undefined;
    user?: ApplicationUser | undefined;
}