import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfilService {

  public url_cazari = 'https://localhost:5001/api/CazariUsers/GetCazariByUser/';
  public url_zboruri= 'https://localhost:5001/api/IstoricZbor/';
  public url_id= 'https://localhost:5001/api/IstoricCazari/GetUserByUsername/';

  constructor(
    public http: HttpClient
  ) { }

  public GetId(username): Observable<any> {
    return this.http.get(`${this.url_id + username}`);
  }
  public GetZboruri(id): Observable<any> {
    return this.http.get(`${this.url_zboruri + id}`);
  }
  public GetCazari(id): Observable<any> {
    return this.http.get(`${this.url_cazari + id}`);
  }

  // public GetId(): Observable<any> {
  //   return this.http.get(`${this.url_id}`);
  // }




}
