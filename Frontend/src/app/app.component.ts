import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
    //id titlu
    var name;
    if (localStorage.getItem('NumePagina')){name = localStorage.getItem('NumePagina');}
    else{name = "Home"}
    document.getElementById("titlu")?.innerHTML = name;
  }
  title = 'Frontend';

  public numePag(nume: string): void {
    localStorage.setItem('NumePagina', nume);
  }

}
``