import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Recenzie } from './recenzie';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.scss']
})
export class ForumComponent implements OnInit {
  submitted = false;
  model = new Recenzie('', '');
  recenzieForm: FormGroup;

  constructor() {
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

}
