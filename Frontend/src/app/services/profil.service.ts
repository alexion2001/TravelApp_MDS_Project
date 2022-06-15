import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProfilService {

  public url_cazari = 'https://localhost:5001//api/CazariUsers/GetCazariByUser/{user}';
  public url_zboruri= 'https://localhost:5001//api/IstoricZbor/{idZborbyUser}';
  constructor(
    public http: HttpClient
  ) { }


}
