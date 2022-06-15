import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  public url = 'https://localhost:5001/api/Accounts/login';
  constructor(
    public hhtp:HttpClient
  ) { }

public getAccount(log): Observable<any>{
  return this.hhtp.get(`${this.url}`,log);
}
}