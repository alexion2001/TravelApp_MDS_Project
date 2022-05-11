import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';



@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.scss']
})
export class ProfilComponent implements OnInit {

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
  }

  public logout(): void {
    localStorage.setItem('Role', 'AnonimUser');
    this.router.navigate(['/login']);
  }

  public obiective(): void {
    
    
  }
  public restaurant(): void {
    
    
  }

}
