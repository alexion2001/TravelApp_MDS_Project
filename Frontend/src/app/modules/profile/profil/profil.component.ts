import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { ProfilService } from 'src/app/services/profil.service';



@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.scss']
})
export class ProfilComponent implements OnInit {
  
  panelOpenState = false;
  public email;
  public IdClient;

  public planificaForm: FormGroup = new FormGroup( 
    {
        oras: new FormControl(''),
      
    });
   

  constructor(
    private router: Router,
    private profilService: ProfilService,
  ) { }
  get oras(): AbstractControl{
    return this.planificaForm;
  }

  ngOnInit(): void {
    this.email = localStorage.getItem('User');
    this.AfisId(this.email);
    this.IdClient = localStorage.getItem('IdClient');
    this.AfisZbor('13FA8F6B-05AD-4F53-B383-42DBD39C7120');
    this.AfisCazare(this.IdClient);

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

  public AfisZbor(id): void{
    this.profilService.GetZboruri(id).subscribe(

      (result) => {
        console.log(result);
        for (var i = 0; i < result.length; i++)
          {
            // const id = result[i].id;
           const data_plecare = result[i].data_plecare;
           const data_retur = result[i].data_retur;
           const oras_plecare = result[i].oras_plecare;
           const oras_retur = result[i].oras_sosire;
           const buget = result[i].buget;
           const zbor = document.createElement("p");
           zbor.innerHTML = "Zbor:" + oras_plecare + " -> " + oras_retur + "\n" + data_plecare + " -> " + data_retur + ' buget:' +buget;
          
           if (document.getElementById("istoricZboruri") != null)
           {
            document.getElementById("istoricZboruri")?.appendChild(zbor);
           }
          }
        
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public AfisCazare(id): void{
    this.profilService.GetZboruri(id).subscribe(
      (result) => {
        console.log(result);
        
        for (var i = 0; i < result.length; i++)
          {
            // const id = result[i].id;
           const data_plecare = result[i].data_venire;
           const data_retur = result[i].data_plecare;
           const oras = result[i].oras;
           const buget = result[i].buget;
           const cazare = document.createElement("p");
           cazare.innerHTML = "Cazare:" + oras + " cu muget " + buget + "\n" + data_plecare + " -> " + data_retur;
          
           if (document.getElementById("istoricCazari") != null)
           {
            document.getElementById("istoricCazari")?.appendChild(cazare);
           }
          }
        
      },
      (error) => {
        console.error(error);
      }
    );
  }


  public AfisId(username): void{
    this.profilService.GetId(username).subscribe(
      (result) => {
        console.log(result);
        
        // for (var i = 0; i < result.length; i++)
        //   {
        //    const id = result[i].id;
        //    localStorage.setItem('IdClient',id);
          // }
        
      },
      (error) => {
        console.error(error);
      }
    );
  }
}