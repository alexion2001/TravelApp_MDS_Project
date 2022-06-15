import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Detalii } from './detalii';
import { DatePipe } from '@angular/common';
import { Cazare } from './cazare';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss'],
  providers: [DatePipe]
})
export class FiltersComponent implements OnInit {
  submittedDetalii = false;
  submittedCazare = false;
  currentDate = new Date();
  model = new Detalii('', '', '', new Date(), new Date(), 0);
  cazare = new Cazare('', new Date(), new Date(), '');
  detaliiForm: FormGroup;
  cazareForm: FormGroup;

  constructor(private datePipe: DatePipe) {
    this.detaliiForm = new FormGroup({
      email: new FormControl(''),
      orasPlecare: new FormControl(''),
      orasDestinatie: new FormControl(''),
      dataPlecare: new FormControl(this.datePipe.transform(this.currentDate, 'yyyy-MM-dd')),
      dataSosire: new FormControl(this.datePipe.transform(this.currentDate, 'yyyy-MM-dd')),
      buget: new FormControl(0)
    });
    this.cazareForm = new FormGroup({
      oras: new FormControl(''),
      dataCheckIn: new FormControl(this.datePipe.transform(this.currentDate, 'yyyy-MM-dd')),
      dataCheckOut: new FormControl(this.datePipe.transform(this.currentDate, 'yyyy-MM-dd')),
      buget: new FormControl('')
    });
   }

  ngOnInit(): void {
  }

  onSubmitDetalii() {
    this.submittedDetalii = true;
    this.model.email = this.detaliiForm.value.email;
    this.model.orasPlecare = this.detaliiForm.value.orasPlecare;
    this.model.orasDestinatie = this.detaliiForm.value.orasDestinatie;
    this.model.dataPlecare = this.detaliiForm.value.dataPlecare;
    this.model.dataSosire = this.detaliiForm.value.dataSosire;
    this.model.buget = this.detaliiForm.value.buget;
    var url = "https://www.momondo.com/flight-search/"+ this.model.orasPlecare + "-"+this.model.orasDestinatie+"/"+this.model.dataPlecare+"/"+this.model.dataSosire + "?isSEM=true&sort=bestflight_a";
    window.open(url, "_blank");
  }

  onSubmitCazare() {
    this.submittedCazare = true;
    this.cazare.oras = this.cazareForm.value.oras;
    this.cazare.dataCheckIn = this.cazareForm.value.dataCheckIn;
    this.cazare.dataCheckOut = this.cazareForm.value.dataCheckOut;
    this.cazare.buget = this.cazareForm.value.buget;
    var url = "https://www.momondo.com/hotel-search/" +this.cazare.oras + "/"+this.cazare.dataCheckIn+"/"+this.cazare.dataCheckOut+"/2adults?sort=rank_a";
    window.open(url, "_blank");
  }

}
