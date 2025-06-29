import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TableService {

  constructor(private http:HttpClient) { }

  url1="https://localhost:7291/api/Table/AddTable/";
  url2="https://localhost:7291/api/Table/FetchTable/";
  url3="https://localhost:7291/api/Table/DeleteTable/";
  url4="https://localhost:7291/api/Table/GetTable/";
  url5="https://localhost:7291/api/Table/UpdateTable/";

  fetchTable(){
    return this.http.get(this.url2);
  }

  addTable(tdata:any){
    return this.http.post(this.url1, tdata);
  }

  deleteTable(tid:any){
    return this.http.delete(this.url3+tid);
  }

  getTable(tid:any){
    return this.http.get(this.url4+tid);
  }

  updateTable(tdata:any){
    return this.http.put(this.url5, tdata);
  }
}
