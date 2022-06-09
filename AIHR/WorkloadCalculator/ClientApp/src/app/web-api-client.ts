//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.16.1.0 (NJsonSchema v10.7.2.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface ICalculationClient {
    create(command: CreateCalculationCommand): Observable<number>;
    get(): Observable<CalculationVm>;
}

@Injectable({
    providedIn: 'root'
})
export class CalculationClient implements ICalculationClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    create(command: CreateCalculationCommand): Observable<number> {
        let url_ = this.baseUrl + "/api/Calculation";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCreate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCreate(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<number>;
                }
            } else
                return _observableThrow(response_) as any as Observable<number>;
        }));
    }

    protected processCreate(response: HttpResponseBase): Observable<number> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    get(): Observable<CalculationVm> {
        let url_ = this.baseUrl + "/api/Calculation";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<CalculationVm>;
                }
            } else
                return _observableThrow(response_) as any as Observable<CalculationVm>;
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<CalculationVm> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = CalculationVm.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export interface ICoursesClient {
    get(): Observable<CourseVm>;
}

@Injectable({
    providedIn: 'root'
})
export class CoursesClient implements ICoursesClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    get(): Observable<CourseVm> {
        let url_ = this.baseUrl + "/api/Courses";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<CourseVm>;
                }
            } else
                return _observableThrow(response_) as any as Observable<CourseVm>;
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<CourseVm> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = CourseVm.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export class CreateCalculationCommand implements ICreateCalculationCommand {
    startDate?: Date;
    endDate?: Date;
    totalCoursesDuration?: number;
    coursesIdsList?: number[] | undefined;

    constructor(data?: ICreateCalculationCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.startDate = _data["startDate"] ? new Date(_data["startDate"].toString()) : <any>undefined;
            this.endDate = _data["endDate"] ? new Date(_data["endDate"].toString()) : <any>undefined;
            this.totalCoursesDuration = _data["totalCoursesDuration"];
            if (Array.isArray(_data["coursesIdsList"])) {
                this.coursesIdsList = [] as any;
                for (let item of _data["coursesIdsList"])
                    this.coursesIdsList!.push(item);
            }
        }
    }

    static fromJS(data: any): CreateCalculationCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateCalculationCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["startDate"] = this.startDate ? this.startDate.toISOString() : <any>undefined;
        data["endDate"] = this.endDate ? this.endDate.toISOString() : <any>undefined;
        data["totalCoursesDuration"] = this.totalCoursesDuration;
        if (Array.isArray(this.coursesIdsList)) {
            data["coursesIdsList"] = [];
            for (let item of this.coursesIdsList)
                data["coursesIdsList"].push(item);
        }
        return data;
    }
}

export interface ICreateCalculationCommand {
    startDate?: Date;
    endDate?: Date;
    totalCoursesDuration?: number;
    coursesIdsList?: number[] | undefined;
}

export class CalculationVm implements ICalculationVm {
    calculations?: CalculationDto[] | undefined;

    constructor(data?: ICalculationVm) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["calculations"])) {
                this.calculations = [] as any;
                for (let item of _data["calculations"])
                    this.calculations!.push(CalculationDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CalculationVm {
        data = typeof data === 'object' ? data : {};
        let result = new CalculationVm();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.calculations)) {
            data["calculations"] = [];
            for (let item of this.calculations)
                data["calculations"].push(item.toJSON());
        }
        return data;
    }
}

export interface ICalculationVm {
    calculations?: CalculationDto[] | undefined;
}

export class CalculationDto implements ICalculationDto {
    startDate?: Date;
    endDate?: Date;
    weeklyStudyHours?: number;
    courses?: string | undefined;

    constructor(data?: ICalculationDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.startDate = _data["startDate"] ? new Date(_data["startDate"].toString()) : <any>undefined;
            this.endDate = _data["endDate"] ? new Date(_data["endDate"].toString()) : <any>undefined;
            this.weeklyStudyHours = _data["weeklyStudyHours"];
            this.courses = _data["courses"];
        }
    }

    static fromJS(data: any): CalculationDto {
        data = typeof data === 'object' ? data : {};
        let result = new CalculationDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["startDate"] = this.startDate ? this.startDate.toISOString() : <any>undefined;
        data["endDate"] = this.endDate ? this.endDate.toISOString() : <any>undefined;
        data["weeklyStudyHours"] = this.weeklyStudyHours;
        data["courses"] = this.courses;
        return data;
    }
}

export interface ICalculationDto {
    startDate?: Date;
    endDate?: Date;
    weeklyStudyHours?: number;
    courses?: string | undefined;
}

export class CourseVm implements ICourseVm {
    courses?: CourseDto[] | undefined;

    constructor(data?: ICourseVm) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["courses"])) {
                this.courses = [] as any;
                for (let item of _data["courses"])
                    this.courses!.push(CourseDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CourseVm {
        data = typeof data === 'object' ? data : {};
        let result = new CourseVm();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.courses)) {
            data["courses"] = [];
            for (let item of this.courses)
                data["courses"].push(item.toJSON());
        }
        return data;
    }
}

export interface ICourseVm {
    courses?: CourseDto[] | undefined;
}

export class CourseDto implements ICourseDto {
    id?: number;
    name?: string | undefined;
    duration?: number;

    constructor(data?: ICourseDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.duration = _data["duration"];
        }
    }

    static fromJS(data: any): CourseDto {
        data = typeof data === 'object' ? data : {};
        let result = new CourseDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["duration"] = this.duration;
        return data;
    }
}

export interface ICourseDto {
    id?: number;
    name?: string | undefined;
    duration?: number;
}

export class SwaggerException extends Error {
    override message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((event.target as any).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}