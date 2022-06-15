import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup = new FormGroup( 
    {
        nume: new FormControl(''),
        prenume: new  FormControl(''),
        email: new  FormControl(''),
        tel: new  FormControl(''),
        parola: new  FormControl('')
    });


  constructor(private router: Router,
    ) { }

    get nume(): FormGroup{
      return this.registerForm.get('nume') as FormGroup;
    }
    get parola(): AbstractControl{
      return this.registerForm;
    }
    get tel(): AbstractControl{
      return this.registerForm;
    }
  
    get prenume(): AbstractControl{
      return this.registerForm;
    }
    get email(): AbstractControl{
      return this.registerForm;
    }
  
  

  ngOnInit(): void {}

    public register(): void {
      
      console.log("Te-ai inregistrat !");

      var nume = this.registerForm.controls['nume'].value;
      localStorage.setItem('Nume',nume);

      var prenume = this.registerForm.controls['prenume'].value;
      localStorage.setItem('Prenume',prenume);

      var email = this.registerForm.controls['email'].value;
      localStorage.setItem('Email',email);

      var tel= this.registerForm.controls['tel'].value;
      localStorage.setItem('Telefon',tel);

      var parola = this.registerForm.controls['parola'].value;
      localStorage.setItem('parola',parola);

      this.router.navigate(['/login']);
    }

  
  }

