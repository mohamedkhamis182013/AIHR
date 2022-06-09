import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private SERVER_URL = "https://localhost:7194/api";
  errorMessage: any;

  constructor(private httpClient:HttpClient) { }

  public get(url:string){
		return this.httpClient.get(this.SERVER_URL + url);
	}

  public post(url:string, obj:any){
    const headers = new HttpHeaders()
      .set('Content-Type', "application/json").set("Accept", "application/json");
    //const content_ = JSON.stringify();
    let url_ = this.SERVER_URL + url;
    url_ = url_.replace(/[?&]$/, "");
   return this.httpClient.post(url_, obj,{headers})
  }
}
