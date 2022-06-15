import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ForumService {

  public url = "https://localhost:5001/api/Recenzii";

  constructor(
    public http: HttpClient,
    ) { }

    public GetRecenzii(): Observable<any> {
      return this.http.get(`${this.url}`);
    }
    public putRecenzie(comanda): Observable<any> {

      return this.http.post(`${this.url}`, comanda);
    }
}

