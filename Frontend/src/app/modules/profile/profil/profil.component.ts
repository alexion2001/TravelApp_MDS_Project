import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';



@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.scss']
})
export class ProfilComponent implements OnInit {
  
  panelOpenState = false;
  public email;

  public planificaForm: FormGroup = new FormGroup( 
    {
        oras: new FormControl(''),
      
    });
   

  constructor(
    private router: Router,
  ) { }
  get oras(): AbstractControl{
    return this.planificaForm;
  }

  ngOnInit(): void {
    this.email = localStorage.getItem('Email');
  }

  public logout(): void {
    localStorage.setItem('Role', 'AnonimUser');
    this.router.navigate(['/login']);
  }

  public obiective(): void {
    var url = "https://www.google.com/search?q=Obiective+turistice+" + this.planificaForm.controls['oras'].value;
    window.open(url, "_blank");
    
  }
  public restaurant(): void {
    var url = "https://www.google.com/search?q=restaurante+" + this.planificaForm.controls['oras'].value;
    window.open(url, "_blank");
    
  }

}
