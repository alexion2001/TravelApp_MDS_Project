import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    public loginForm: FormGroup = new FormGroup( 
    {
        username: new FormControl(''),
        parola: new  FormControl('')
    });
  constructor(
    private router: Router,
    private loginService: LoginService
  ) { }

  //getters
  get username(): FormGroup{
    return this.loginForm.get('username') as FormGroup;
  }
  get parola(): AbstractControl{
    return this.loginForm;
  }

  ngOnInit(): void {
  }

  // public login():void{

  //   var log = {
  //     "uniqueIdentifier": this.username ,
  //     "password": this.parola
  //   }
  //   this.login2(log);
  // }

  public login(): void {
    // this.loginService.getAccount(log).subscribe(
    //   (result) => {
    //     console.log(result);

        localStorage.setItem('Role', 'LoggedUser');

      console.log("Te-ai logat !");

      console.log(this.loginForm.value);
      var user = this.loginForm.controls['username'].value;
      localStorage.setItem('User',user);
      var parola = this.loginForm.controls['parola'].value;
      localStorage.setItem('parola',parola);

      this.router.navigate(['/profil']);


    //   },
    //   (error) => {
    //     console.log(error);
    //   }
    // );


  }


}