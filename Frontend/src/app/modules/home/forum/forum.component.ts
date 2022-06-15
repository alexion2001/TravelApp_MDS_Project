import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Recenzie } from './recenzie';
import { ForumService } from 'src/app/services/forum.service';
import { LiveAnnouncer } from '@angular/cdk/a11y';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.scss']
})
export class ForumComponent implements OnInit {
  submitted = false;
  model = new Recenzie('', '');
  recenzieForm: FormGroup;

  constructor(private forumService: ForumService,
    private _liveAnnouncer: LiveAnnouncer) {
    this.recenzieForm = new FormGroup({
      oras: new FormControl(''),
      mesaj: new FormControl('')
    });
    
   }

  ngOnInit(): void {
  }

  onSubmit() {
    this.submitted = true;
    this.model.oras = this.recenzieForm.value.oras;
    this.model.mesaj = this.recenzieForm.value.mesaj;
  }

  public AfisRecenzii(): void{
    this.forumService.GetRecenzii().subscribe(
      (result) => {
        console.log(result);
        
        for (var i = 0; i < result.length; i++)
          {
            // const id = result[i].id;
           const oras = result[i].oras;
           const mesaj = result[i].mesaj;
           const recenzie = document.createElement("p");
           recenzie.innerHTML = "Orasul " + oras + ":" + mesaj;
          
           if (document.getElementById("input-viewed") != null)
           {
            document.getElementById("input-viewed")?.appendChild(recenzie);
           }
          }
        
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
