import { NONE_TYPE } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  {

    
  constructor(
    private router: Router,
    
  ) { }

  ngAfterViewInit(): void {
    
    //id titlu
    var name;
    if (localStorage.getItem('NumePagina')){name = localStorage.getItem('NumePagina');}
    else{name = "Home"}
    var titlu = document.getElementById('titlu');
    if (name && name != 'none'){
      titlu!.innerHTML = name;
      //localStorage.setItem('NumePagina', 'none');
      
    }
      
    else
      titlu!.innerHTML = "Home";
   
    
    
  }
  title = 'Frontend';

  public numePag(nume: string): void {
    localStorage.setItem('NumePagina', nume);
    
  }

}
``